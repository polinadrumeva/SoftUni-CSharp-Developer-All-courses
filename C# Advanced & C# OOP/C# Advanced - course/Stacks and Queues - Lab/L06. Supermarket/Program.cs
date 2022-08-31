using System;
using System.Collections.Generic;

namespace L06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    foreach (string customer in customers)
                    {
                        Console.WriteLine(customer);
                    }
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(command);
                }

            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
