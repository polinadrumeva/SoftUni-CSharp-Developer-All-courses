using System;
using System.Collections.Generic;

namespace AL06._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsCanGo = int.Parse(Console.ReadLine());
            int passedCars = 0;
            Queue<string> cars = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numberOfCarsCanGo; i++)
                    {
                        if (cars.Count > 0)
                        {
                            passedCars++;
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                        }

                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
