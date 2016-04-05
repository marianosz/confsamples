using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.Formatting;

namespace FixEmptyCatch
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FixEmptyCatchCodeFixProvider)), Shared]
    public class FixEmptyCatchCodeFixProvider : CodeFixProvider
    {
        private const string title = "Fix Catch";

        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(DiagnosticWithCodeFixEmptyCatchAnalyzer.DiagnosticId); }
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            var token = root.FindToken(diagnosticSpan.Start);

            if (token.IsKind(SyntaxKind.CatchKeyword))
            {
                // Register a code action that will invoke the fix.
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: title,
                        createChangedDocument: c => ReplaceEmptyCatch(root, diagnosticSpan, context),
                        equivalenceKey: title),
                    diagnostic);
            }
        }

        private Task<Document> ReplaceEmptyCatch(SyntaxNode root, TextSpan diagnosticSpan, 
            CodeFixContext context)
        {
            return Task.Run(() =>
            {
                var token = root.FindToken(diagnosticSpan.Start);

                var catchBlock = (CatchClauseSyntax)token.Parent;
                var tryStmt = (TryStatementSyntax)catchBlock.Parent;

                var throwStatement = SyntaxFactory.ThrowStatement();
                var newStatements = new SyntaxList<StatementSyntax>().Add(throwStatement);
                var newBlock = SyntaxFactory.Block().WithStatements(newStatements);
                var newCatchBlock = SyntaxFactory.CatchClause().WithBlock(newBlock).
                    WithAdditionalAnnotations(Formatter.Annotation);

                var newRoot = root.ReplaceNode(catchBlock, newCatchBlock);

                return context.Document.WithSyntaxRoot(newRoot);
            });
        }
    }
    
}