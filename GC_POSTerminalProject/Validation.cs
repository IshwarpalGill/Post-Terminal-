using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GC_POSTerminalProject
{
    class Validation
    {
        //Validation for what you want to do
        public static int ValidInput(string input)
        {
            int inputNum = 0;

            while (true)
            {
                try
                {
                    inputNum = int.Parse(input);
                    if (inputNum > 3 || inputNum < 1)
                    {
                        Console.WriteLine("Please choose a number 1-3");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        return inputNum;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please type a number 1-3");
                    input = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Please choose a number");
                    input = Console.ReadLine();
                }
            }

        }



        // Validation for what items are wanted
        public static int ValItemFromList(string input, int listCount)
        {
            int item = 0;
            //bool again = true;
            while (true)
            {
                try
                {
                    item = int.Parse(input);
                    //again = false;
                    if (item > listCount || item < 1)
                    {
                        Console.WriteLine($"Please enter a number 1-{listCount}.");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        return item;
                    }
                }
                //catch (IndexOutOfRangeException)
                //{
                //    Console.WriteLine("That item does not exist. Please enter a number 1-15.");
                //    input = Console.ReadLine();
                //    //again = true;
                //}
                catch (FormatException)
                {
                    Console.WriteLine($"Please enter only a number 1-{listCount}.");
                    input = Console.ReadLine();
                    //again = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"Please enter only a number 1-{listCount}.");
                    input = Console.ReadLine();
                    //again = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please enter a number 1-{listCount}.");
                    input = Console.ReadLine();
                    //again = true;
                }
            }

        }

        //Validation for amount
        public static int ValidAmount()
        {
            string amountString = Console.ReadLine();
            int amount = 0;


            while (true)
            {
                try
                {
                    amount = int.Parse(amountString);
                    if (amount > 10)
                    {
                        Console.WriteLine("Please choose an item less than 10");
                        amountString = Console.ReadLine();
                    }
                    else if (amount < 1)
                    {
                        Console.WriteLine("Please choose a greater amount");
                        amountString = Console.ReadLine();
                    }
                    else
                    {
                        return amount;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer");
                    amountString = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number");
                    amountString = Console.ReadLine();
                }
            }
        }

        //Validation continue shopping or checkout
        public static bool ToContinue(string input)
        {
            string wtd = input;
            while (true)
            {
                try
                {
                    if (input.ToLower() == "continue")
                    {
                        return true;
                    }
                    else if (input.ToLower() == "checkout")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Please choose Continue or Checkout");
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please choose Continue or Checkout");
                    input = Console.ReadLine();
                }
            }
        }

        //validation for payment type
        public static string ValidPaymentType(string paymentType)
        {
            string pt = paymentType;
            while (true)
            {
                try
                {
                    if (pt.ToLower() == "cash" || pt.ToLower() == "check" || pt.ToLower() == "credit card" || pt.ToLower() == "credit" || pt.ToLower() == "card")
                    {
                        return pt.ToLower();

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid payment type: Cash, Check, or Credit Card");
                        pt = Console.ReadLine();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter cash, check, or credit card");
                    pt = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter cash, check, or credit card");
                    pt = Console.ReadLine();
                }
            }
        }
        //validation for just check and credit card when cash is below the total amount
        public static string ValidSecondPaymentType(string paymentType)
        {
            string pt = paymentType;
            while (true)
            {
                try
                {
                    if (pt.ToLower() == "check" || pt.ToLower() == "credit card" || pt.ToLower() == "credit" || pt.ToLower() == "card")
                    {
                        return pt.ToLower();

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid payment type:vCheck or Credit Card");
                        pt = Console.ReadLine();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter check or credit card");
                    pt = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter check or credit card");
                    pt = Console.ReadLine();
                }
            }
        }

        public static decimal ValidCash(string amount)
        {
            decimal cash = 0;

            while (true)
            {
                try
                {
                    cash = decimal.Parse(amount);
                    Match getCash = Regex.Match(amount, @"^[0-9]+(\.[0-9]{1,2})?$");
                    if (getCash.Success)
                    {
                        return cash;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid amount in the following format: XXX.XX");
                        amount = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid amount");
                    amount = Console.ReadLine();
                }

            }

        }

        //validation for checks
        public static bool ValidCheck(string checkNum)
        {

            while (true)
            {
                try
                {
                    Match getMatch = Regex.Match(checkNum, @"^([0 - 9]{0,9})\d$");
                    if (getMatch.Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please re-enter check number");
                    checkNum = Console.ReadLine();
                }
            }
        }

        //Valid for debit/credit card
        public static char ValidCreditCard(string cardNum)
        {
            int valCard = 0;
            while (true)
            {
                try
                {
                    //valCard = int.Parse(cardNum);
                    //regex pattern for Visa, MasterCard, American Express, Discover in order
                    Match getVisa = Regex.Match(cardNum, @"^4[0-9]{12}(?:[0-9]{3})?$");
                    Match getMC = Regex.Match(cardNum, @"^5[1-5][0-9]{14}$");
                    Match getAmex = Regex.Match(cardNum, @"^3[47][0-9]{13}$"); 
                    Match getDiscover = Regex.Match(cardNum, @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$");

                    if (getVisa.Success)
                    {
                        return cardNum[0];
                    }
                    else if (getMC.Success)
                    {
                        return cardNum[0];
                    }
                    else if (getAmex.Success)
                    {
                        return cardNum[0];
                    }
                    else if (getDiscover.Success)
                    {
                        return cardNum[0];
                    }
                    else
                    {
                        Console.WriteLine("Please retype card number");
                        cardNum = Console.ReadLine();
                    }
                }
                //catch (FormatException)
                //{
                //    Console.WriteLine("Please enter numbers");
                //    cardNum = Console.ReadLine();
                //}
                catch (Exception)
                {
                    Console.WriteLine("Please enter card number");
                    cardNum = Console.ReadLine();
                }
            }
        }

        //validation for card date
        public static bool ValExpirDate(string cardDate)
        {
            while (true)
            {
                try
                {

                    Match getDate = Regex.Match(cardDate, @"^([0]{1}[1-9]{1}|[10-12]{2})\/[0-9]{2}$");
                    if (getDate.Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please use numbers for the date in the following format: MM/YY");
                    cardDate = Console.ReadLine();
                }
            }
        }

        //validation for CVV number
        public static bool ValidCVV(char cardNum, string cvv)
        {
            int cvvNum = 0;
            while (true)
            {
                try
                {
                    cvvNum = Convert.ToInt32(new string(cardNum, 1));

                    
                    Match cvvMatch1 = Regex.Match(cvv, @"^[0-9]{3}$");
                    Match cvvMatch2 = Regex.Match(cvv, @"^[0-9]{4}$");

                    if (cvvNum == 3)
                    {
                        if (cvvMatch2.Success)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid CVV number");
                            cvv = Console.ReadLine();
                        }
                    }
                    else
                    {
                        if (cvvMatch1.Success)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid CVV number");
                            cvv = Console.ReadLine(); 
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter numbers");
                }

            }
        }

        //validation for restart or close
        public static bool RestartOrClose(string input)
        {
            while (true)
            {
                try
                {
                    if (input.ToLower() == "restart")
                    {
                        return true;
                    }
                    else if (input.ToLower() == "close")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Please type restart or close");
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please type restart or close");
                    input = Console.ReadLine();
                }
            }

        }

    }
}
