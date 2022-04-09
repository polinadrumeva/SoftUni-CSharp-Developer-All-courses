using System;
using System.Collections.Generic;

namespace E02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resourceAndQuantity = new Dictionary<string, double>();

            string command = Console.ReadLine();
            while (command != "stop")
            {
                double resource = double.Parse(Console.ReadLine());

                if (resourceAndQuantity.ContainsKey(command))
                {
                    resourceAndQuantity[command] += resource;
                }
                else
                {
                    resourceAndQuantity.Add(command, resource);
                }

                command = Console.ReadLine();
            }

            foreach (var item in resourceAndQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
