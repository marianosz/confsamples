using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryExample.Interfaces;

namespace FactoryExample.Engines
{
    public class ChevroletEngine : IEngine
    {
        public object[] Parts { get; set; }

        public ChevroletEngine()
        {
            Parts = new object[10];
        }

        public bool TestStart()
        {
            Console.WriteLine("Chevrolet On");

            return true;
        }
    }
}