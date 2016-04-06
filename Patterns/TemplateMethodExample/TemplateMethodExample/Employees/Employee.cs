using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethodExample.Employees
{
    public abstract class Employee
    {
        public static Employee GetEmployee(int number, String name, int type)
        {
            switch (type)
            {
                case 1: //Tester
                    return new Tester() { Name = name, Number = number };
                case 2: //Developer
                    return new Developer() { Name = name, Number = number };
                case 3: //Manager
                    return new Manager() { Name = name, Number = number };
                default:
                    return null;
            }
        }

        public int Number { get; set; }

        public String Name { get; set; }
        
        public abstract int Type { get; }

        public void DoSomething()
        {
            DoSomething1();

            DoSomething2();

            SomeOperation();

            DoSomething3();
        }

        private void DoSomething3()
        {
           
        }

        private void DoSomething2()
        {
           
        }

        private void DoSomething1()
        {
           
        }

        public abstract int SomeOperation();
       
        public abstract void GetDescription();

    }
}