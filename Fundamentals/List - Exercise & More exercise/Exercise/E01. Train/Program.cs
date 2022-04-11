using System;
using System.Collections.Generic;
using System.Linq;

namespace E01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> passengerInWagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split().ToArray();

            while (commands[0] != "end")
            {
                if (commands.Length <= 1)
                {

                    for (int i = 0; i < passengerInWagons.Count; i++)
                    {
                        if (passengerInWagons[i] < maxCapacity)
                        {
                            if ((passengerInWagons[i] + int.Parse(commands[0]) <= maxCapacity))
                            {
                                passengerInWagons[i] += int.Parse(commands[0]);
                                break;
                            }
                            else
                            {
                                continue;
                            }

                        }

                    }
                }
                else
                {
                    int numOfPassenger = 0;
                    string command = commands[0];
                    numOfPassenger = int.Parse(commands[1]);
                    passengerInWagons.Add(numOfPassenger);
                }

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(String.Join(" ", passengerInWagons));
        }
    }
}
