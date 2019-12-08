using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GC_POSTerminalProject
{
    class Product
    {
        private string name;
        private decimal priceeach;
        private string category;
        private bool istaxable;
        private int quantity;
        private decimal lineTotal;
        private decimal taxTotal;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal PriceEach
        {
            get { return priceeach; }
            set { priceeach = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public bool IsTaxable
        {
            get { return istaxable; }
            set { istaxable = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public decimal LineTotal
        {
            get { return lineTotal; }
            set { lineTotal = value; }
        }
        public decimal TaxTotal
        {
            get { return taxTotal; }
            set { taxTotal = value; }
        }

        public Product()
        {

        }
        public Product(string name, decimal priceeach, string category, bool istaxable)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
        }
        public Product(string name, decimal priceeach, string category, bool istaxable, int quantity)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
            Quantity = quantity;
        }
        public Product(string name, decimal priceeach, string category, bool istaxable, int quantity, decimal linetotal)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
            Quantity = quantity;
            LineTotal = linetotal;
        }
        public Product(string name, decimal priceeach, string category, bool istaxable, int quantity, decimal linetotal, decimal taxtotal)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
            Quantity = quantity;
            LineTotal = linetotal;
            TaxTotal = taxtotal;
        }

        public static List<Product> GetProductList()
        {
            List<Product> tempList = new List<Product>();

            StreamReader reader = new StreamReader(@"..\..\..\ProductDB.txt");

            string data = reader.ReadLine();

            while (data != null)
            {
                string[] product = data.Split(',');

                try
                {
                    tempList.Add(new Product(
                        product[0],
                        Convert.ToDecimal(product[1]),
                        product[2],
                        Convert.ToBoolean(product[3]),
                        0));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                data = reader.ReadLine();
            }
            reader.Close();

            return tempList;
        }

        public static void ModifyProductList(List<Product> currentProductList)
        {
            string userInput;
            int itemSelected;
            bool startOver = false;

            do
            {
                Console.WriteLine("add or remove");
                userInput = Validation.AddOrRemove(Console.ReadLine());

                if (userInput.ToLower() == "add")
                {
                    string name;
                    decimal price = 0m;
                    string category;
                    bool taxable;

                    Console.WriteLine("What is the name of the new product");
                    name = Validation.ValidString(Console.ReadLine());

                    Console.WriteLine("What is the price of the new product");
                    price = Validation.ValidDecimal(Console.ReadLine());

                    Console.WriteLine("What is the category of the new product");
                    category = Validation.ValidString(Console.ReadLine());

                    Console.WriteLine("Is the new product taxable?");
                    taxable = Validation.YesOrNo(Console.ReadLine());

                    StreamWriter sw = new StreamWriter(@"..\..\..\ProductDB.txt", true);
                    sw.WriteLine("");
                    sw.Write($"{name},{price},{category},{taxable}");

                    sw.Close();

                    Console.WriteLine("Item has been added. Returning to the Main Menu");
                }
                else if (userInput.ToLower() == "remove")
                {
                    Program.DisplayItems(currentProductList);
                    Console.WriteLine("What item do you want to remove (Enter the number to the left of the item)");
                    itemSelected = Validation.ValItemFromList(Console.ReadLine(), currentProductList.Count);

                    Console.WriteLine($"You are about to remove item {itemSelected}.) {currentProductList[itemSelected-1].Name} are you sure?\nIf yes, retype the administrative password, otherwise, type in cancel.");
                    userInput = Console.ReadLine();
                    if (userInput == "gcAdmin")
                    {
                        currentProductList.RemoveAt(itemSelected - 1);

                        StreamWriter sw = new StreamWriter(@"..\..\..\ProductDB.txt");
                        foreach (var product in currentProductList)
                        {
                            sw.WriteLine($"{product.Name},{product.PriceEach},{product.Category},{product.IsTaxable}");
                        }
                        sw.Close();
                        Console.WriteLine("The Item has been removed. Returning to Main Menu");
                        System.Threading.Thread.Sleep(5000);
                        startOver = false;
                    }
                    else
                    {
                        startOver = true;
                    }
                }
                else
                {
                    Console.WriteLine("Input incorrect, please type in add or remove");
                    startOver = true;
                }
            } while (startOver == true);
        }
    }
}
