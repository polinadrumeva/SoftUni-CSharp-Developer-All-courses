using System;
using System.Collections.Generic;
using System.Linq;

namespace AE04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string command = Console.ReadLine();
            var odd = new List<int>();
            var even = new List<int>();
            Predicate<int> isEvenOrOdd = x => x % 2 == 0;
            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (isEvenOrOdd(i))
                {
                    even.Add(i);
                }
                else
                {
                    odd.Add(i);
                }
            }

            if (command == "odd")
            {
                Console.WriteLine(String.Join(" ", odd));
            }
            else if (command == "even") 
            {
                Console.WriteLine(String.Join(" ", even));
            } 
        }
    }
}
