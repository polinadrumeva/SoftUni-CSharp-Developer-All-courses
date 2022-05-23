using System;
using System.Linq;

namespace L03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).OrderByDescending(x => x).ToArray();
            for (int i = 0; i < 3; i++)
            {
                if (numbers.Length < 3)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        Console.Write($"{numbers[j]} ");
                    }
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.Write($"{numbers[i]} ");
                }
                
            }
            Console.WriteLine();
        }
    }
}
