using System;
using System.Collections.Generic;

namespace AL03._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> products = new SortedDictionary<string, Dictionary<string, double>>();

            string command;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] productInfo = command.Split(", ");
                string store = productInfo[0];
                string product = productInfo[1];
                double price = double.Parse(productInfo[2]);

                if (!products.ContainsKey(store))
                {
                    products.Add(store, new Dictionary<string, double>());

                }
                if (!products[store].ContainsKey(product))
                {
                    products[store].Add(product, price);
                }
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key}->");
               
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
