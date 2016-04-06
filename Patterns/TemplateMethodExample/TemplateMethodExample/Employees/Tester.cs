using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethodExample.Employees
{
    public class Tester : Employee
    {
        public override int Type
        {
            get
            {
                return 1;
            }
        }

        public override int SomeOperation()
        {
            return 1;
        }

        public override void GetDescription()
        {
            Console.WriteLine("I´m a Tester");
        }
    }
}
