using System;
using System.Collections.Generic;
using System.Linq;

namespace AE01._Reverse_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> reserveNumbers = new Stack<int>(numbers);
            while (reserveNumbers.Count != 0)
            {
                Console.Write($"{reserveNumbers.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}
