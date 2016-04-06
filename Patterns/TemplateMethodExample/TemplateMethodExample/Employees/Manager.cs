using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethodExample.Employees
{
    public class Manager : Employee
    {
        public override int Type
        {
            get
            {
                return 3;
            }
        }

        public override int SomeOperation()
        {
            return 3;
        }

        public override void GetDescription()
        {
            Console.WriteLine("I´m a Manager");
        }
    }
}
