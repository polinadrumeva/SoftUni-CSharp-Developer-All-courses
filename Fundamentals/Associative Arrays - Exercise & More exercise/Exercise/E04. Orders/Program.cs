using System;
using System.Collections.Generic;
using System.Linq;

namespace E04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> ordersInformation = new Dictionary<string, List<double>>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] information = command.Split().ToArray();
                string name = information[0];
                double price = double.Parse(information[1]);
                double quantity = double.Parse(information[2]);

                if (ordersInformation.ContainsKey(name))
                {
                    ordersInformation[name][0] = price;
                    ordersInformation[name][1] += quantity;
                }
                else
                {
                    ordersInformation.Add(name, new List<double>());
                    ordersInformation[name].Add(price);
                    ordersInformation[name].Add(quantity);
                }
            }

            foreach (var item in ordersInformation)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");

            }
        }
    }
}
