using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> all = new List<IBuyer>();
            double totalSum = 0;

            int numberRotation = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberRotation; i++)
            {
                string[] dataArg = Console.ReadLine().Split(" ");
                if (dataArg.Length == 3)
                {
                    IBuyer newRebel = new Rebel(dataArg[0], int.Parse(dataArg[1]), dataArg[2]);
                    all.Add(newRebel);
                }
                else if (dataArg.Length == 4)
                {
                    IBuyer newCitizen = new Citizens(dataArg[0], int.Parse(dataArg[1]), dataArg[2], dataArg[3]);
                    all.Add(newCitizen);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer searchedObj = all.FirstOrDefault(n => n.Name == command);
                
                if (searchedObj != null)
                {
                    totalSum += searchedObj.BuyFood();

                }
               
            }

            Console.WriteLine(totalSum);

            
        }
    }
}
