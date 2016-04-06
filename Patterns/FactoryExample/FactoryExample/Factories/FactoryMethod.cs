using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Engines;

namespace FactoryExample.Factories
{
    public static class FactoryMethod
    {
        public static MercedesEngine CreateMercedesEngine()
        {
            return new MercedesEngine();
        }

        public static ChevroletEngine CreateChevroletEngine()
        {
            return new ChevroletEngine();
        }
    }


    public static class MercedesEngineFactory
    {
        public static MercedesEngine CreateDiesel()
        {
            return new MercedesEngine(true);
        }

        public static MercedesEngine CreateNitro()
        {
            return new MercedesEngine(true, false);
        }

        public static MercedesEngine CretaTurbo()
        {
            return new MercedesEngine(false, true);
        }
    }
}
