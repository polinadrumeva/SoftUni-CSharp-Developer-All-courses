using System;
using System.Collections.Generic;

namespace L07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArr = command.Split(", ");
                string direction = cmdArr[0];
                string carsNumber = cmdArr[1];

                switch (direction)
                {
                    case "IN":
                        parking.Add(carsNumber);
                        break;
                    case "OUT":
                        parking.Remove(carsNumber);
                        break;
                }
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
