using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product> 
            {
                new Product(100, 20),
                new Product(100, 200),
                new Product(100, 40),
                new Product(100, 300)
            };

            var sellProduct = products.ElementAt(3);

            Console.WriteLine(sellProduct.GetSalePrice());

            sellProduct.Sell(280);

            Console.WriteLine(sellProduct.GetSalePrice());

            Console.WriteLine("Press any Key to close...");
            Console.ReadKey();
        }
    }
}