using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GC_POSTerminalProject
{
    class Validation
    {
        // Validation for what items are wanted
        public static int ValItemFromList(string input)
        {
            int item = 0;
            //bool again = true;
            while (true)
            {
                try
                {
                    item = int.Parse(input);
                    //again = false;
                    return item;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("That item does not exist. Please enter a number 1-15.");
                    input = Console.ReadLine();
                    //again = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter only a number 1-15.");
                    input = Console.ReadLine();
                    //again = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter only a number 1-15.");
                    input = Console.ReadLine();
                    //again = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number 1-15.");
                    input = Console.ReadLine();
                    //again = true;
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
                    if (pt.ToLower() == "cash" || pt.ToLower() == "check" || pt.ToLower() == "credit card")
                    {
                        return pt.ToLower();

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid payment type: Cash, Check, or Credit Card");
                        pt = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter cash, check, or credit card");
                    pt = Console.ReadLine();
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
        public static bool ValidCreditCard(string cardNum)
        {
            int valCard = 0;
            while (true)
            {
                try
                {
                    valCard = int.Parse(cardNum);
                    //regex pattern for Visa, MasterCard, American Express, Discover in order
                    Match getMatch = Regex.Match(cardNum,
                    @"^4[0-9]{12}(?:[0-9]{3})? | (?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12} | 3[47][0-9]{13} 6(?:011|5[0-9]{2})[0-9]{12}$");

                    if (getMatch.Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }  
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numbers");
                    cardNum = Console.ReadLine();
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
        public static bool ValidCVV(string cardNum, string cvv)
        {
            int cvvNum = 0;
            while (true)
            {
                try
                {
                    cvvNum = int.Parse(cvv);

                    Match cardMatch = Regex.Match(cardNum, @"^3[47][0-9]{13}$");
                    Match cvvMatch1 = Regex.Match(cvv, @"^[0-9]{3}$");
                    Match cvvMatch2 = Regex.Match(cvv, @"^[0-9]{4}$");

                    if (cardMatch.Success)
                    {
                        if (cvvMatch2.Success)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (cvvMatch2.Success)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter numbers");
                }
                
            }
        }

    }
}
