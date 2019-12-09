using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GC_POSTerminalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Boolean to repeat or stop doWhile
            bool startOver = false;
            do
            {
                //Clearing the Console mainly for the second order
                Console.Clear();

                //Generating Lists to hold products and items you are shopping for
                List<Product> productList = new List<Product>();
                List<Product> shoppingCart = new List<Product>();

                //Assigning Products to ProductList
                productList = Product.GetProductList();

                int inputValue = 0, itemSelected = 0, quantity = 0, cartQuantity = 0;
                string userInput;
                bool accessGranted = false;

                Console.WriteLine("Welcome to GC Electronics!");

                Console.WriteLine("\nWhat would you like to do today?");

                //Calling Method to Display the actions a user can take
                DisplayActionList();

                inputValue = Validation.ValidInput(Console.ReadLine());

                //If user enters a 1, they will go into the shopping area
                if (inputValue == 1)
                {
                    bool continueShopping = false;

                    do
                    {
                        //Clearing the screen of the previous code to keep it looking neat
                        Console.Clear();

                        Console.WriteLine("Welcome to the shop!\n");

                        //Sends the Product List to a void method containing a foreach to iterate through the list that will also sort it
                        DisplayItems(productList);

                        //Displays the number of items user has in their shopping cart if they are adding more than a single item
                        if (shoppingCart.Count > 0)
                        {
                            cartQuantity = 0;
                            foreach (var item in shoppingCart)
                            {
                                cartQuantity = cartQuantity + item.Quantity;
                            }
                            Console.WriteLine($"\nCurrent Item(s) in Shopping Cart: {cartQuantity}");
                        }

                        //Asking user to select product
                        Console.WriteLine("\nPlease add an item to your cart by typing in the number to the left of the item");
                        itemSelected = Validation.ValItemFromList(Console.ReadLine(), productList.Count);

                        //Asking user to input quantity
                        Console.WriteLine("\nHow many would you like to add?");
                        quantity = Validation.ValidAmount();

                        //Adding item and quantity selected to shopping cart
                        shoppingCart.Add(AddToCart(productList, itemSelected, quantity));
                        
                        //Allowing user to add more items or head to checkout
                        Console.WriteLine("\nWould you like to add another item to your cart or proceed to checkout?\nPlease type in \"continue\" or \"checkout\"");
                        continueShopping = Validation.ToContinue(Console.ReadLine());
                    } while (continueShopping == true);

                    //Sends shopping cart to payment selections and payment screen
                    PaymentChoice(shoppingCart);

                    //Allows user to create another transaction or close pos
                    Console.WriteLine("\nWould you like to make another transaction or close the terminal?\nPlease type in \"Restart\" or \"Close\"");
                    startOver = Validation.RestartOrClose(Console.ReadLine());
                }
                //allows user to add or remove product if they have the admin password
                else if (inputValue == 2)
                {
                    //this section only allows 3 attempts to put in password else it returns to main menu
                    for (int i = 1; i < 4; i++)
                    {
                        Console.WriteLine("Please enter the administrative password");
                        userInput = Console.ReadLine();

                        if(userInput == "gcAdmin")
                        {
                            i = 50;
                            accessGranted = true;
                        }
                        else
                        {
                            Console.WriteLine($"Password was incorrect. You have {3-i} attempt(s) left");
                        }
                    }
                    if (accessGranted == true)
                    {
                        Product.ModifyProductList(productList);
                        startOver = true;
                    }
                    else
                    {
                        Console.WriteLine("Access denied. You will be returned to the main menu in 5 seconds");
                        startOver = true;
                        Thread.Sleep(5000);
                    }
                }
                else
                {
                    startOver = false;
                }
            } while (startOver == true);

            Console.WriteLine("Thank you for using the POS");
        }

        public static Product AddToCart(List<Product> list, int item, int quantity)
        {
            //creating new product to hold data of item user wants to purchase
            Product product = new Product();
            if (list[item - 1].IsTaxable == true)
            {
                product = new Product(list[item - 1].Name, list[item - 1].PriceEach, list[item - 1].Category, list[item - 1].IsTaxable, quantity, list[item - 1].PriceEach * quantity, list[item - 1].PriceEach * quantity * 0.06m);
            }
            else
            {
                product = new Product(list[item - 1].Name, list[item - 1].PriceEach, list[item - 1].Category, list[item - 1].IsTaxable, quantity, list[item - 1].PriceEach * quantity);
            }
            return product;
        }
        public static void DisplayItems(List<Product> newList)
        {
            //simple foreach loop to write list to screen after it was sorted
            int i = 1;

            newList.OrderBy(c => c.Category).ThenBy(n => n.Name);

            foreach (var item in newList)
            {
                Console.WriteLine($"{i}.) {item.Name} | {item.PriceEach} | {item.Description}");
                i++;
            }
        }
        public static void DisplayActionList()
        {
            List<string> actionList = new List<string>()
            {
                new string("1) Shop"),
                new string("2) Add or Remove Product"),
                new string("3) Close POS\n")
            };

            foreach (var option in actionList)
            {
                Console.WriteLine(option);
            }
        }
        public static void PaymentChoice(List<Product> shoppingCart)
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m, change = 0m;

            bool valid = false;

            Console.WriteLine();
            //displays users totals
            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((Payment.STotal(item.Quantity, item.PriceEach) + subTotal),2, MidpointRounding.ToZero);
                salesTax = Math.Round((Payment.Tax(subTotal) + salesTax),2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round((Payment.GrandTotal(subTotal, salesTax)),2, MidpointRounding.ToZero);

            //displays users shopping cart
            Console.WriteLine("You have selected the following items:\n");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }

            Console.WriteLine($"\nSubtotal: {subTotal.ToString("C2")}\nSales Tax: {salesTax.ToString("C2")}\n\nGrand Total: {grandTotal.ToString("C2")}\n");

            Console.WriteLine("Continuing to Checkout screen in 5 seconds");
            Thread.Sleep(5000);

            do
            {
                //clearing screen to make it neat
                Console.Clear();

                //displays grand total to be paid
                Console.WriteLine($"Grand Total: {grandTotal.ToString("C2")}\n");
                
                //allows user to select method of payment
                Console.WriteLine("\nPayment choice: Cash, Credit, Check..");
                string paymentType = Validation.ValidPaymentType(Console.ReadLine());

                if (paymentType == "cash")
                {
                    //sends grandtotal to PayCash method and allows user to enter exact amount or more than needed to return change. Will not allow partial payments
                    change = Payment.PayCash(grandTotal);
                    Thread.Sleep(5000);
                    Console.Clear();
                   
                    //sends items and change to receipt list
                    Receipt.DisplayCashReceipt(shoppingCart, change);
                }
                else if (paymentType == "credit" || paymentType == "credit card" || paymentType == "card")
                {
                    //user enters cc number
                    Console.WriteLine("Please enter your credit card number");
                    string ccNumber = Validation.ValidCreditCard(Console.ReadLine());

                    //sends cc number to Payment class to gather remaining info to validate
                    Payment.CCPayment(ccNumber);
                    Console.WriteLine("Successful! Please wait for your receipt");
                    Thread.Sleep(5000);
                    Console.Clear();

                    //sends items and cc number to receipt
                    Receipt.DisplayCreditCardReceipt(shoppingCart, ccNumber);
                }
                else if (paymentType == "check")
                {
                    //validates check number
                    Console.WriteLine("Please enter your check number");
                    int checknum = Validation.ValidCheck(Console.ReadLine());
                    Console.WriteLine("Please wait");
                    Thread.Sleep(5000);
                    Console.Clear();
                    
                    //sends items and check number to receipt
                    Receipt.DisplayCheckReceipt(shoppingCart, checknum);
                }

            } while (valid == true);
        }
    }
}
