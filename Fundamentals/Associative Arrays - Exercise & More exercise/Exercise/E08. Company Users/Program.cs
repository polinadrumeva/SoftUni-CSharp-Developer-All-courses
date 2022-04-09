using System;
using System.Collections.Generic;
using System.Linq;

namespace E08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companysName = new Dictionary<string, List<string>>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] infos = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = infos[0];
                string employeesId = infos[1];  
                List<string> newList = new List<string>();

                if (companysName.ContainsKey(name))
                {
                    if (!companysName[name].Contains(employeesId))
                    {
                        companysName[name].Add(employeesId);
                    }
                    
                }
                else
                {
                    companysName.Add(name, newList);
                    companysName[name].Add(employeesId);

                }
                
            }

            foreach (var item in companysName)
            {
                Console.Write($"{item.Key}");
                Console.WriteLine();

                foreach (string newEmployye in item.Value)
                {
                    Console.WriteLine($"--{newEmployye}");
                }
                
            }
        }
    }
}
