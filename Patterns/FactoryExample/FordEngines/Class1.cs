using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Interfaces;

namespace FordEngines
{
    public class FordEngineFactory : IEngineFactory
    {
        public IEngine Assemble()
        {
            return new FordEngine();
        }
    }

    public class FordEngine : IEngine
    {
        public object[] Parts { get; set;}

        public bool TestStart()
        {
            Console.WriteLine("Ford On!!");

            return true;
        }
    }
}
