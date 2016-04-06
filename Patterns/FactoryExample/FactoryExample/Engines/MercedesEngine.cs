using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Interfaces;

namespace FactoryExample.Engines
{
    public class MercedesEngine: IEngine
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

        public object[] Parts { get; set; }

        public MercedesEngine()
        {
            Parts = new object[10];
        }

        private MercedesEngine(bool nitro, bool turbo)
        {
            Parts = new object[10];
        }

        private MercedesEngine(bool diesel)
        {
            Parts = new object[10];
        }

        public bool TestStart()
        {
            Console.WriteLine("Mercedes On");

            return true;
        }
    }
}
