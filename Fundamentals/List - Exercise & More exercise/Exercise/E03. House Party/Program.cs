using System;
using System.Collections.Generic;
using System.Linq;


namespace E03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i <= count - 1; i++)
            {
                string[] comingGuest = Console.ReadLine().Split().ToArray();

                switch (comingGuest[2])
                {
                    case "going!":
                        if (guests.Contains(comingGuest[0]))
                        {
                            Console.WriteLine($"{comingGuest[0]} is already in the list!");
                        }
                        else
                        {
                            guests.Add(comingGuest[0]);
                        }
                        break;
                    case "not":
                        if (!guests.Contains(comingGuest[0]))
                        {
                            Console.WriteLine($"{comingGuest[0]} is not in the list!");
                        }
                        else
                        {
                            guests.Remove(comingGuest[0]);
                        }
                        break;
                }

            }

            Console.WriteLine(String.Join("\n", guests));
        }
    }
}
