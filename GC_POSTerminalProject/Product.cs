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
    }
}
