using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateMethodExample.Employees;

namespace TemplateMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = Employee.GetEmployee(1, "Mende", 2);

            employee.GetDescription();

            Console.WriteLine("Press any Key to close...");
            Console.ReadKey();
        }
    }
}
