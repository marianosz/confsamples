using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Demos
{
    class SingletonDemo
    {
        public static void Run()
        {
            // Constructor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    class Singleton
    {
        private static Singleton _instance;
        // Constructor is 'protected'
        protected Singleton()
        {
        }
        public static Singleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}

