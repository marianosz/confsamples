using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Optimization;
using System.Diagnostics;
using SassAndCoffee.JavaScript.CoffeeScript;
using SassAndCoffee.JavaScript;
using SassAndCoffee.Core;

namespace BundlingMinificationDemo
{
    public class CoffeeMinify : JsMinify
    {
        public override void Process(BundleContext context, BundleResponse response)
        {
            var jsRuntimeProvider = new InstanceProvider<IJavaScriptRuntime>(() => new IEJavaScriptRuntime());

            response.Content = new CoffeeScriptCompiler(jsRuntimeProvider).Compile(response.Content);

            base.Process(context, response);
        }
    }
}