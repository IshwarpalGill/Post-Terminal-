using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace GC_POSTerminalProject
{
    class Payment
    {
        //Properties

        public static double SubTotal { set; get; }
        public static double SalesTax { set; get; }
        public static double Total { set; get; }

        //Receipt methods
        //public static void CashRecipt(List<Product> productlist)

        //Payment methods
        public static double PayCash(double change)
        {
            //Get amount they are paying 
            do
            {
                Console.WriteLine("Amount Tindered");

                double amount = Convert.ToDouble(Console.ReadLine());

                if (amount <= Total)
                {
                    change = amount - Total;
                    Console.WriteLine($"{change}");
                }
                else
                {
                    Console.WriteLine("Please enter valid amount");
                }
            } while (false);
            return change;
        }

        public static bool CCPayment(bool valid)
        {
            string ccNumber;
            string ccPattern = @"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$";
            string expDate;
            string expDatePattern = @"^[0-9]{2}/[0-9]{2}$";
            string cvv;
            string cvvPattern = @"^[0-9]{3}$";

            Regex ccRgx = new Regex(ccPattern);
            Regex expRgx = new Regex(expDatePattern);
            Regex cvvRgx = new Regex(cvvPattern);

            do
            {
                Console.WriteLine("CC#");
                ccNumber = Console.ReadLine();

                if (ccRgx.IsMatch(ccNumber))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter valid CC#");
                    valid = false;
                }
            } while (valid == false);


            do
            {
                Console.WriteLine("ExpDate");
                expDate = Console.ReadLine();

                if (expRgx.IsMatch(expDate))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter valid expiration date");
                    valid = false;
                }
            } while (valid == false);

            do
            {
                Console.WriteLine("CVV");
                cvv = Console.ReadLine();

                if (ccRgx.IsMatch(cvv))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter valid CVV");
                    valid = false;
                }

            } while (valid == false);
            return (valid);
        }
        public static bool CheckPayment(bool cleared)
        {
            do
            {
                Console.WriteLine("Please enter the amount of check");
                double amount = Convert.ToDouble(Console.ReadLine());

                if (amount == Total)
                {
                    cleared = true;
                }
                else
                {
                    Console.WriteLine("Please valid amount");
                    cleared = false;
                }
            } while (cleared == false);

            do
            {
                Console.WriteLine("Please enter check number");
                string checkNum = Console.ReadLine();
                cleared = true;

            } while (cleared == false);
            return (cleared);
        }
        public static decimal Tax(decimal subTotal)
        {
            decimal saleTax = subTotal * 0.06M;
            return (saleTax);
        }

        public static decimal STotal(int quantity, decimal itemPrice)
        {
            decimal subTotal = quantity * itemPrice;
            return subTotal;
        }


        public static decimal GrandTotal(decimal subTotal, decimal saleTax)
        {
            decimal grandTotal = subTotal + saleTax;
            return grandTotal;
        }
    }
}
