using System;
using System.Collections.Generic;
using System.Linq;

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

                int inputValue = 0, itemSelected = 0, quantity = 0;
                decimal subTotal = 0m, taxTotal = 0m, orderTotal = 0m;

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
                            Console.WriteLine($"\nCurrent Item(s) in Shopping Cart: {shoppingCart.Count}");
                        }

                        Console.WriteLine("\nPlease add an item to your cart by typing in the number to the left of the item");
                        itemSelected = Validation.ValItemFromList(Console.ReadLine());
                        Console.WriteLine("How many would you like to add?");
                        quantity = Validation.ValidAmount();

                        shoppingCart.Add(AddToCart(productList, itemSelected, quantity));

                        Console.WriteLine("continue shopping or checkout");
                        continueShopping = Validation.ToContinue(Console.ReadLine());
                    } while (continueShopping == true);

                    foreach (var item in shoppingCart)
                    {
                        subTotal = item.LineTotal + subTotal;
                        taxTotal = item.TaxTotal + taxTotal;
                        orderTotal = subTotal + taxTotal + orderTotal;
                    }

                    Console.WriteLine($"{subTotal},{taxTotal},{orderTotal}");

                    Console.WriteLine("new action?");
                    startOver = bool.Parse(Console.ReadLine());
                }
                else if (inputValue == 2)
                {
                    Console.WriteLine("This feature is not availble at this time but will be implemented soon.");
                    Console.WriteLine("new action?");
                    startOver = bool.Parse(Console.ReadLine());
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
            bool valid = false;
            do
            {
                Console.WriteLine("Payment choice: Cash, Credit, Check..");
                string paymentType = Console.ReadLine().ToLower();

                Validation.ValidPaymentType(paymentType);

                if (paymentType == "cash")
                {

                    foreach (Product item in shoppingCart)
                    {
                        decimal subTotal = Payment.STotal(item.Quantity, item.PriceEach);
                        decimal saleTax = Payment.Tax(subTotal);
                        decimal grandTotal = Payment.GrandTotal(subTotal, saleTax);

                    }

                }
                else if (paymentType == "credit")
                {

                    foreach (Product item in shoppingCart)
                    {
                        decimal subTotal = Payment.STotal(item.Quantity, item.PriceEach);
                        decimal salesTax = Payment.Tax(subTotal);
                        decimal grandTotal = Payment.GrandTotal(subTotal, salesTax);
                    }
                }
                else if (paymentType == "check")
                {

                    foreach (Product item in shoppingCart)
                    {
                        decimal subTotal = Payment.STotal(item.Quantity, item.PriceEach);
                        decimal salesTax = Payment.Tax(subTotal);
                        decimal grandTotal = Payment.GrandTotal(subTotal, salesTax);
                    }
                }

            } while (valid == true);
        }
    }
}
