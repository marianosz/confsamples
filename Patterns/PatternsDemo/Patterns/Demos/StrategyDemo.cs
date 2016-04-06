using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Demos
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Strategy Design Pattern.
    /// </summary>
    class StrategyDemo
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Run()
        {
            StrategyContext context;

            // Three contexts following different strategies
            context = new StrategyContext(new ConcreteStrategyA());
            context.ContextInterface();

            context = new StrategyContext(new ConcreteStrategyB());
            context.ContextInterface();

            context = new StrategyContext(new ConcreteStrategyC());
            context.ContextInterface();

        }
    }
    
    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }
    
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
            "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }
    
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
            "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }
 
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
            "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class StrategyContext
    {
        private Strategy _strategy;
        // Constructor
        public StrategyContext(Strategy strategy)
        {
            this._strategy = strategy;
        }
        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}
