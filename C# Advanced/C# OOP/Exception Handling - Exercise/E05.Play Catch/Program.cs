using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int countException = 0;

            string command = Console.ReadLine();
            while (true)
            {
                string[] cmdArg = command.Split(" ");
                try
                {
                    string typeCommand = cmdArg[0];
                    if (typeCommand == "Replace")
                    {
                        int index = int.Parse(cmdArg[1]);
                        int element = int.Parse(cmdArg[2]);
                        numbers[index] = element;

                    }
                    else if (typeCommand == "Print")
                    {
                        int startIndex = int.Parse(cmdArg[1]);
                        int endIndex = int.Parse(cmdArg[2]);

                        List<int> forPrint = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            forPrint.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", forPrint));
                    }
                    else if (typeCommand == "Show")
                    {
                        int index = int.Parse(cmdArg[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countException++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countException++;
                }

                if (countException == 3)
                {
                    break;
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
