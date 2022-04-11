using System;
using System.Linq;

namespace E07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int[] num = numbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Console.Write(String.Join(" ", num));
                Console.Write(" ");
            }
            Console.WriteLine();

        }
    }
}
