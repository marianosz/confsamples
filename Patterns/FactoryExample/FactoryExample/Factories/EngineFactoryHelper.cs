using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Interfaces;
using System.Configuration;

namespace FactoryExample.Factories
{
    public static class EngineFactoryHelper
    {
        public static IEngineFactory GetEngineFactory()
        {
            var type = Type.GetType(ConfigurationManager.AppSettings["FactoryImplementation"]);

            return (IEngineFactory)Activator.CreateInstance(type);
        }
    }
}
