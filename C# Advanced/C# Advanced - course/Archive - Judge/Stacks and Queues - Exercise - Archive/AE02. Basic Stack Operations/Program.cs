using System;
using System.Collections.Generic;
using System.Linq;

namespace AE02._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commandNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();
            int count = 0;

            int pushNumber = commandNumbers[0];
            int popNumber = commandNumbers[1];
            int peekNumber = commandNumbers[2];

            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < number.Length; i++)
            {
                numbers.Push(number[i]);
                count++;
                if (count == pushNumber)
                {
                    break;
                }
            }

            for (int k = 0; k < popNumber; k++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(peekNumber))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{numbers.Min()}");
            }
        }
    }
}
