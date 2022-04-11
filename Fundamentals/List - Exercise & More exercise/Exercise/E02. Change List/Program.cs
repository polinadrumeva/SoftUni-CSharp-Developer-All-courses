using System;
using System.Collections.Generic;
using System.Linq;

namespace E02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] commands = Console.ReadLine().Split().ToArray();
            while (commands[0] != "end")
            {
                string command = commands[0];
                int element = int.Parse(commands[1]);
                if (command == "Delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (element == numbers[i])
                        {
                            numbers.RemoveAt(i);
                            i = -1;
                        }
                    }
                }
                if (commands.Length > 2)
                {
                    int index = int.Parse(commands[2]);
                    numbers.Insert(index, element);

                }

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(String.Join(" ", numbers));

        }
    }
}
