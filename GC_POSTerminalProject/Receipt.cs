using System;
using System.Collections.Generic;
using System.Text;

namespace GC_POSTerminalProject
{
    class Receipt
    {

        public static void DisplayCashReceipt(List<Product> shoppingCart, decimal amountPaid, decimal change )
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m;

            Console.WriteLine("\n\t**********Receipt**********");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------------------------------------------------");

            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((Payment.STotal(item.Quantity, item.PriceEach) + subTotal), 2, MidpointRounding.ToZero);
                salesTax = Math.Round((Payment.Tax(subTotal) + salesTax), 2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round((Payment.GrandTotal(subTotal, salesTax)), 2, MidpointRounding.ToZero);

            Console.WriteLine("You have selected the following items:");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }

            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Subtotal:", $"{subTotal.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Sales Tax:", $"{salesTax.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,33}", $"Grand Total:", $"{grandTotal.ToString("C2")}"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Payment Type: Cash");
            Console.WriteLine("Amount Paid:", ${ Payment.PayCash.ToString("C2")});
            Console.WriteLine($"Change:");
            Console.WriteLine("\n\t==========THANK YOU!==========");
        }

        public static void DisplayCheckReceipt(List<Product> shoppingCart, decimal salesTax, decimal grandTotal, decimal subTotal, decimal amountPaid, decimal change)
        {
            Console.WriteLine("\n\t**********Receipt**********");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------------------------------------------------");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Subtotal:", $"{subTotal.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Sales Tax:", $"{salesTax.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,33}", $"Grand Total:", $"{grandTotal.ToString("C2")}"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Payment Type: Check");
            Console.WriteLine($"Check Number: ");
            Console.WriteLine("\n\t==========THANK YOU!==========");
        }
        public static void DisplayCreditCardReceipt(List<Product> shoppingCart, decimal salesTax, decimal grandTotal, decimal subTotal, decimal amountPaid, decimal change)
        {
            Console.WriteLine("\n\t**********Receipt**********");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------------------------------------------------");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Subtotal:", $"{subTotal.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Sales Tax:", $"{salesTax.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,33}", $"Grand Total:", $"{grandTotal.ToString("C2")}"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Payment Type: Credit Card");
            Console.WriteLine($"Card Number: ");
            Console.WriteLine("\n\t==========THANK YOU!==========");
        }
    }
}
