using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Demos
{
    class ProxyDemo
    {
        public static void Run()
        {
            // Create proxy and request a service
            Proxy proxy = new Proxy();

            proxy.Request();
        }
    }
    
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        public abstract void Request();
    }
    
    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    /// <summary>
    /// The 'Proxy' class
    /// </summary>
    class Proxy : Subject
    {
        private RealSubject _realSubject;
        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }
}
