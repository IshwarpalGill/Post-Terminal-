using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GC_POSTerminalProject
{
    class Product
    {
        #region private fields
        private string name;
        private decimal priceeach;
        private string description;
        private string category;
        private bool istaxable;
        private int quantity;
        private decimal lineTotal;
        private decimal taxTotal;
        #endregion

        #region properties
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
        public string Description
        {
            get { return description; }
            set { description = value; }
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
        #endregion

        #region Constructors
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
        public Product(string name, decimal priceeach, string category, bool istaxable, string description)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
            Description = description;
        }
        public Product(string name, decimal priceeach, string category, bool istaxable, string description, int quantity)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
            Description = description;
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
        #endregion

        #region Methods
        //Creates List
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
                        product[4],
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
                Console.Clear();
                Console.WriteLine("Welcome to the administrative options.\n\nIf you would like to add an item, type in \"add\"\nIf you would like to remove an  item, type in \"remove\"");
                userInput = Validation.AddOrRemove(Console.ReadLine());

                if (userInput.ToLower() == "add")
                {
                    string name, category, description;
                    decimal price = 0m;
                    bool taxable;

                    Console.Clear();

                    Console.WriteLine("In order to create a new item, you will need to enter the following:\na Name, the Price per Item, a Category, and whether the item is Taxable or not");

                    Console.WriteLine("\nWhat is the name of the new product");
                    name = Validation.ValidString(Console.ReadLine());

                    Console.WriteLine("\nWhat is the description of the new product");
                    description = Validation.ValidString(Console.ReadLine());

                    Console.WriteLine("\nWhat is the price of the new product");
                    price = Validation.ValidDecimal(Console.ReadLine());

                    Console.WriteLine("\nWhat is the category of the new product");
                    category = Validation.ValidCat(Console.ReadLine());

                    Console.WriteLine("\nIs the new product taxable? (Please enter \"yes\" or \"no\")");
                    taxable = Validation.YesOrNo(Console.ReadLine());

                    StreamWriter sw = new StreamWriter(@"..\..\..\ProductDB.txt", true);
                    sw.WriteLine();
                    sw.Write($"{name},{price},{category},{taxable},{description}");

                    sw.Close();

                    Console.WriteLine("\nItem has been added. Returning to the Main Menu");
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
                            sw.WriteLine($"{product.Name},{product.PriceEach},{product.Category},{product.IsTaxable}, {product.Description}");
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
        #endregion
    }
}
