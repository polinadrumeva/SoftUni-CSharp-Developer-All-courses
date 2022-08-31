using System;
using System.Collections.Generic;
using System.Linq;

namespace E02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commandNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();
            int count = 0;

            int enqueueNumber = commandNumbers[0];
            int dequeueNumber = commandNumbers[1];
            int peekNumber = commandNumbers[2];

            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < number.Length; i++)
            {
                numbers.Enqueue(number[i]);
                count++;
                if (count == enqueueNumber)
                {
                    break;
                }
            }

            for (int k = 0; k < dequeueNumber; k++)
            {
                numbers.Dequeue();
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
