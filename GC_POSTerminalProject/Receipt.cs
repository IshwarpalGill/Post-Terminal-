using System;
using System.Collections.Generic;
using System.Text;

namespace GC_POSTerminalProject
{
    class Receipt
    {

        public static void DisplayCashReceipt(List<Product> shoppingCart,decimal change)
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m, amountPaid = 0m;

            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((Payment.STotal(item.Quantity, item.PriceEach) + subTotal), 2, MidpointRounding.ToZero);
                salesTax = Math.Round((Payment.Tax(subTotal) + salesTax), 2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round((Payment.GrandTotal(subTotal, salesTax)), 2, MidpointRounding.ToZero);
            amountPaid = grandTotal + change;

            Console.WriteLine("\n\t**********Receipt**********");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------------------------------------------------");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("{0,-18} {1,30}", $"Subtotal:", $"{subTotal.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-18} {1,30}", $"Sales Tax:", $"{salesTax.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-18} {1,30}", $"Grand Total:", $"{grandTotal.ToString("C2")}"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Payment Type: Cash");
            Console.WriteLine($"Amount Paid: {amountPaid.ToString("C2")}");
            if (change != 0)
            {
                Console.WriteLine($"Change: {change}");
            }
            Console.WriteLine("\n\t==========THANK YOU!==========");
        }

        public static void DisplayCheckReceipt(List<Product> shoppingCart, int checkNumber)
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m;

            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((Payment.STotal(item.Quantity, item.PriceEach) + subTotal), 2, MidpointRounding.ToZero);
                salesTax = Math.Round((Payment.Tax(subTotal) + salesTax), 2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round((Payment.GrandTotal(subTotal, salesTax)), 2, MidpointRounding.ToZero);

            Console.WriteLine("\n\t**********Receipt**********");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------------------------------------------------");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Subtotal:", $"{subTotal.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Sales Tax:", $"{salesTax.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,33}", $"Grand Total:", $"{grandTotal.ToString("C2")}"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Payment Type: Check");
            Console.WriteLine($"Check Number: {checkNumber}");
            Console.WriteLine("\n\t==========THANK YOU!==========");
        }
        public static void DisplayCreditCardReceipt(List<Product> shoppingCart, string ccNumber)
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m;
            string lastFour = ccNumber.Substring(ccNumber.Length - 4);

            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((Payment.STotal(item.Quantity, item.PriceEach) + subTotal), 2, MidpointRounding.ToZero);
                salesTax = Math.Round((Payment.Tax(subTotal) + salesTax), 2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round((Payment.GrandTotal(subTotal, salesTax)), 2, MidpointRounding.ToZero);

            Console.WriteLine("\n\t**********Receipt**********");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------------------------------------------------");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Subtotal:", $"{subTotal.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,35}", $"Sales Tax:", $"{salesTax.ToString("C2")}"));
            Console.WriteLine(string.Format("{0,-10} {1,33}", $"Grand Total:", $"{grandTotal.ToString("C2")}"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Payment Type: Credit Card");
            Console.WriteLine($"Card ending in {lastFour}");
            Console.WriteLine("\n\t==========THANK YOU!==========");
        }
    }
}
