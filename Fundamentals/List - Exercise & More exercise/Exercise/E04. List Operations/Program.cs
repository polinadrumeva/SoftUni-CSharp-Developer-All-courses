using System;
using System.Collections.Generic;
using System.Linq;

namespace E04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] commands = Console.ReadLine().Split().ToArray();
            while (commands[0] != "End")
            {
                string command = string.Empty;
                string commandMove = string.Empty;
                int number = 0;
                int index = 0;
                int count = 0;
                

                if (commands.Length == 2)
                {
                    number = int.Parse(commands[1]);
                    switch (commands[0])
                    {
                        case "Add":
                            numbers = GetAddNumber(numbers, commands);
                            break;
                        case "Remove":
                            if (number >= numbers.Count - 1)
                            {
                                Console.WriteLine("Invalid index");
                                commands = Console.ReadLine().Split().ToArray();
                                continue;

                            }
                            else
                            {
                                numbers = GetRemoveNumber(numbers, commands);
                            }
                            
                            break;

                    }
                }
                else if (commands.Length == 3)
                {
                    bool isNumber = int.TryParse(commands[1], out number);
                    if (isNumber)
                    {
                        index = int.Parse(commands[2]);
                        number = int.Parse(commands[1]);
                        switch (commands[0])
                        {
                            case "Insert":
                                if (index > numbers.Count - 1)
                                {
                                    Console.WriteLine("Invalid index");

                                }
                                else
                                {
                                    numbers = GetInsertNumber(numbers, commands, number, index);
                                }
                                break;
                        }
                    }
                    else
                    {
                        commandMove = commands[1];
                        count = int.Parse(commands[2]);
                        switch (commands[1])
                        {
                            case "left":
                                numbers = GetShiftLeftNumber(numbers, commands, count);
                                break;
                            case "right":
                                numbers = GetShiftRightNumber(numbers, commands, count);
                                break;
                        }
                    }
                }

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
        static List<int> GetAddNumber(List<int> numbers, string[] commands)
        {
            numbers.Add(int.Parse(commands[1]));
            return numbers;
        }
        static List<int> GetRemoveNumber(List<int> numbers, string[] commands)
        {
            numbers.RemoveAt(int.Parse(commands[1]));
            return numbers;
        }
        static List<int> GetInsertNumber(List<int> numbers, string[] commands, int number, int index)
        {
            numbers.Insert(index, number);
            return numbers;
        }
        static List<int> GetShiftLeftNumber(List<int> numbers, string[] commands, int count)
        {
            int i = 0;
            while (count != 0)
            {
                numbers.Add(numbers[i]);
                numbers.RemoveAt(i);
                count--;
            }

            return numbers;
        }
        static List<int> GetShiftRightNumber(List<int> numbers, string[] commands, int count)
        {
            int i = numbers.Count - 1;
            while (count != 0)
            {
                numbers.Insert(0, numbers[i]);
                count--;
            }

            return numbers;
        }
    }
}
