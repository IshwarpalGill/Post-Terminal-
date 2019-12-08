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
        public static decimal PayCash(decimal grandTotal)
        {
            decimal amount = 0m, change = 0m;
            bool doAgain = false;
            //Get amount they are paying 
            do
            {
                Console.WriteLine("Please enter the amount of cash you would like to apply:");

                amount = Validation.ValidCash(Console.ReadLine());

                if (amount == grandTotal)
                {
                    Console.WriteLine("Paid in full");
                    change = grandTotal - amount;
                    return change;
                }
                else if(amount > grandTotal)
                {
                    change = amount - grandTotal;
                    Console.WriteLine($"Change: {change}");
                    return change;
                }
                else
                {
                    Console.WriteLine("That is not a valid amount.");
                    doAgain = true;
                }
            } while (doAgain == true);
            return 0m;
        }

        public static bool CCPayment(bool ccNumber)
        {
            do
            {
                Console.WriteLine("Please enter Credit Card Number");

                char cardNumber = Validation.ValidCreditCard(Console.ReadLine());

                Console.WriteLine("Please enter expiration date");

                bool expNmber = Validation.ValExpirDate(Console.ReadLine());

                Console.WriteLine("Please enter CVV (located on back of card)");


                bool cvvNumber = Validation.ValidCVV(cardNumber, Console.ReadLine());


            } while (false);
            return (true);
            


        }
        public static bool CheckPayment(bool checkNum)
        {
            
            do
            {
                

                Console.WriteLine("Please enter check number");

                checkNum = Validation.ValidCheck(Console.ReadLine());
                

            } while (false);
            return (true);
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
