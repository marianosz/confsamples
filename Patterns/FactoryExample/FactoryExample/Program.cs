using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Factories;
using FactoryExample.Interfaces;
using FactoryExample.Engines;

namespace FactoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = MercedesEngine.CreateDiesel();

            DoQualityAssurance(engine);

            Console.WriteLine("Press any Key to close...");
            Console.ReadKey();
        }

        private static void DoQualityAssurance(IEngine engine)
        {
            engine.TestStart();
        }
    }
}
