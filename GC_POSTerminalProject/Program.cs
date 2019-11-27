using System;
using System.Collections.Generic;

namespace GC_POSTerminalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = Product.GetProductList();

            foreach (var product in productList)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
