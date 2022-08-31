using System;
using System.Collections.Generic;
using System.Linq;

namespace L05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queueNumbers = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    queueNumbers.Enqueue(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(", ", queueNumbers));
        }
    }
}
