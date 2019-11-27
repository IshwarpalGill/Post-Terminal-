using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GC_POSTerminalProject
{
    class Product
    {
        private string name;
        private decimal priceeach;
        private string category;
        private bool istaxable;

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

        public Product(string name, decimal priceeach, string category, bool istaxable)
        {
            Name = name;
            PriceEach = priceeach;
            Category = category;
            IsTaxable = istaxable;
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
                        Convert.ToBoolean(product[3])));
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
