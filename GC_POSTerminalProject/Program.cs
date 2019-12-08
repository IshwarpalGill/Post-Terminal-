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
            bool startOver = false;
            do
            {
                Console.Clear();
                List<Product> productList = new List<Product>();
                List<Product> shoppingCart = new List<Product>();
                shoppingCart.Clear();
                productList.Clear();
                productList = Product.GetProductList();

                int inputValue = 0, itemSelected = 0, quantity = 0, cartQuantity = 0;
                string userInput;
                bool accessGranted = false;

                Console.WriteLine("Welcome to GC Electronics!");

                Console.WriteLine("What would you like to do today?");

                DisplayActionList();

                inputValue = Validation.ValidInput(Console.ReadLine());

                if (inputValue == 1)
                {
                    bool continueShopping = false;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Welcome to the shop!\n");
                        DisplayItems(productList);

                        if (shoppingCart.Count > 0)
                        {
                            foreach (var item in shoppingCart)
                            {
                                cartQuantity = cartQuantity + item.Quantity;
                            }
                            Console.WriteLine($"\nCurrent Item(s) in Shopping Cart: {cartQuantity}");
                        }

                        Console.WriteLine("\nPlease add an item to your cart by typing in the number to the left of the item");
                        itemSelected = Validation.ValItemFromList(Console.ReadLine(), productList.Count);
                        Console.WriteLine("How many would you like to add?");
                        quantity = Validation.ValidAmount();

                        shoppingCart.Add(AddToCart(productList, itemSelected, quantity));

                        Console.WriteLine("continue shopping or checkout");
                        continueShopping = Validation.ToContinue(Console.ReadLine());
                    } while (continueShopping == true);

                    PaymentChoice(shoppingCart);

                    Console.WriteLine("restart or close?");
                    startOver = Validation.RestartOrClose(Console.ReadLine());
                }
                else if (inputValue == 2)
                {
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
        {//shoppingcart class holds Product and new values
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
            int i = 1;

            newList.OrderBy(c => c.Category).ThenBy(n => n.Name);

            foreach (var item in newList)
            {
                Console.WriteLine($"{i}.) {item.Name} {item.PriceEach}");
                i++;
            }
        }
        public static void DisplayActionList()
        {
            List<string> actionList = new List<string>()
            {
                new string("1) Shop"),
                new string("2) Add or Remove Product"),
                new string("3) Close POS")
            };

            foreach (var option in actionList)
            {
                Console.WriteLine(option);
            }
        }
        public static void PaymentChoice(List<Product> shoppingCart)
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m;

            bool valid = false;


            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((Payment.STotal(item.Quantity, item.PriceEach) + subTotal),2, MidpointRounding.ToZero);
                salesTax = Math.Round((Payment.Tax(subTotal) + salesTax),2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round((Payment.GrandTotal(subTotal, salesTax)),2, MidpointRounding.ToZero);

            Console.WriteLine("You have selected the following items:");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name} @ {product.PriceEach.ToString("C2")}");
            }

            Console.WriteLine($"Subtotal: {subTotal.ToString("C2")}\nSales Tax: {salesTax.ToString("C2")}\nGrand Total: {grandTotal.ToString("C2")}");

            do
            {
                Console.WriteLine("Payment choice: Cash, Credit, Check..");
                string paymentType = Validation.ValidPaymentType(Console.ReadLine());

                if (paymentType == "cash")
                {
                    Payment.PayCash(grandTotal);
                }
                else if (paymentType == "credit" || paymentType == "credit card" || paymentType == "card")
                {
                    Payment.CCPayment(valid);
                    
                }
                else if (paymentType == "check")
                {
                    Payment.CCPayment(valid);
                }

            } while (valid == true);
        }
    }
}
