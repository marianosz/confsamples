using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Interfaces;
using FactoryExample.Engines;

namespace FactoryExample.Factories
{
    public class MercedesEngineFactory : IEngineFactory
    {
        public IEngine Assemble()
        {
            var engine = new MercedesEngine();

            var veryExpensiveParts = new object[10];

            engine.Parts = veryExpensiveParts;

            return engine;
        }
    }
}

