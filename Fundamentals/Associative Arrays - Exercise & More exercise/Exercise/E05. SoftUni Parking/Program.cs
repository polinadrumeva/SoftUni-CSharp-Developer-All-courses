using System;
using System.Collections.Generic;
using System.Linq;

namespace E05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> carsInformation = new Dictionary<string, string>();
            int numbersOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfCommands; i++)
            {
                string[] information = Console.ReadLine().Split().ToArray();
                string typeOfCommand = information[0];
                string name = information[1];
                

                switch (typeOfCommand)
                {
                    case "register":
                        string lisenceNumber = information[2];
                        if (carsInformation.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {lisenceNumber}");
                        }
                        else
                        {
                            carsInformation.Add(name, lisenceNumber);
                            Console.WriteLine($"{name} registered {lisenceNumber} successfully");
                        }
                        break;

                    case "unregister":
                        if (!carsInformation.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        else
                        { 
                            Console.WriteLine($"{name} unregistered successfully");
                            carsInformation.Remove(name);
                        }
                        break;

                }

            }


            foreach (var item in carsInformation)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
