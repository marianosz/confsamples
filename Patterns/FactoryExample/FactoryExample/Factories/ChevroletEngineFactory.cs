using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Interfaces;
using FactoryExample.Engines;

namespace FactoryExample.Factories
{
    public class ChevroletEngineFactory : IEngineFactory
    {
        public IEngine Assemble()
        {
            var engine = new ChevroletEngine();

            var veryCheapParts = new object[5];

            engine.Parts = veryCheapParts;

            return engine;
        }
    }
}
