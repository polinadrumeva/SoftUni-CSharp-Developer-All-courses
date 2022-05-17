using System;
using System.Collections.Generic;
using System.Linq;

namespace E03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stackNumbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split();
                int firstCommand = int.Parse(numbers[0]);
                if (firstCommand == 1)
                {
                    int number = int.Parse(numbers[1]);
                    stackNumbers.Push(number);
                }
                else if (firstCommand == 2)
                {
                    if (stackNumbers.Count == 0)
                    {
                        continue;
                    }
                    stackNumbers.Pop();
                }
                else if (firstCommand == 3)
                {
                    if (stackNumbers.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stackNumbers.Max());
                }
                else if (firstCommand == 4)
                {
                    if (stackNumbers.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stackNumbers.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stackNumbers));
        }
    }
}
