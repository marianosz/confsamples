using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethodExample.Employees
{
    public class Developer : Employee
    {
        public override int Type
        {
            get
            {
                return 2;
            }
        }

        public override int SomeOperation()
        {
            return 2;
        }

        public override void GetDescription()
        {
            Console.WriteLine("I´m a Developer");
        }
    }
}
