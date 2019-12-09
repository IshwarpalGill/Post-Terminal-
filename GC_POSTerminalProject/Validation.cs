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
        public static int ValidCheck(string checkNum)
        {
            while (true)
            {
                try
                {
                    Match getMatch = Regex.Match(checkNum, @"^([0-9]{1,9})\d$");
                    if (getMatch.Success)
                    {
                        return int.Parse(checkNum);
                    }
                    else
                    {
                        Console.WriteLine("There was an error with your check number, please try again.");
                        checkNum = Console.ReadLine();
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
        public static string ValidCreditCard(string cardNum)
        {
            //int valCard = 0;
            while (true)
            {
                try
                {
                    //valCard = int.Parse(cardNum);
                    //regex pattern for Visa, MasterCard, American Express, Discover in order
                    Match verifyCC = Regex.Match(cardNum, @"^4[0-9]{15}?$|^5[0-9]{15}$|^6[0-9]{15}$|^3[0-9]{14}$");

                    if (verifyCC.Success)
                    {
                        return cardNum;
                    }
                    else
                    {
                        Console.WriteLine("Please retype card number");
                        cardNum = Console.ReadLine();
                    }
                }
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
                        Console.WriteLine("Please enter a valid date (MM/YY)");
                        cardDate = Console.ReadLine();
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
                    cvv = Console.ReadLine();
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

        //validation for add or remove a Product
        public static string AddOrRemove(string input)
        {
            while (true)
            {
                try
                {
                    if (input.ToLower() == "add" || input.ToLower() == "remove")
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Please type add or remove");
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please type add or remove");
                    input = Console.ReadLine();
                }
            }
        }

        //Validating a string
        public static string ValidString(string input)
        {
            while (true)
            {
                try
                {
                    if (input.Contains(","))
                    {
                        Console.WriteLine("Please try again without a comma");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        return input;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please type a valid product");
                    input = Console.ReadLine();
                }
            }
        }

        public static string ValidCat(string input)
        {
            while (true)
            {
                try
                {
                    Match getCat = Regex.Match(input, @"^([A-Za-z\s*]{1,30})$");
                    if (getCat.Success)
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid category (capital letter beginning each word)");
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid category");
                    input = Console.ReadLine();
                }
            }
        }

        //validation for decimal
        public static decimal ValidDecimal(string input)
        {
            decimal validDec = 0;
            while (true)
            {
                try
                {
                    validDec = decimal.Parse(input);
                    Match getDecimal = Regex.Match(input, @"^[0-9]{1,4}\.[0-9]{2}$");
                    
                    if(getDecimal.Success)
                    {
                        return validDec;
                    }
                    else
                    {
                        Console.WriteLine("Please use a valid price");
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please use a valid price");
                    input = Console.ReadLine();
                }
            }
        }

        //Validating a yes or no and return a bool
        public static bool YesOrNo(string input)
        {
            while (true)
            {
                try
                {
                    if (input.ToLower() == "yes" || input.ToLower() == "y")
                    {
                        return true;
                    }
                    else if (input.ToLower() == "no" || input.ToLower() == "n")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Please type yes or no");
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please type yes or no");
                    input = Console.ReadLine();
                }
            }
        }

    }
}
