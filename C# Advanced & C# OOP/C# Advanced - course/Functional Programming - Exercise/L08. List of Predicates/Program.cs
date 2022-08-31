using System;
using System.Collections.Generic;
using System.Linq;

namespace L08._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> numbers = new List<int>();
            List<int> printNumbers = new List<int>();


            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            foreach (var number in numbers)
            {
                bool isDiviseble = true;
                foreach (var divider in dividers)
                {
                   Predicate<int> predicate = number => number % divider == 0;
                    if (!predicate(number))
                    {
                        isDiviseble = false;
                        break;
                    }
                }
                if (isDiviseble)
                { 
                printNumbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", printNumbers));
        }
    }
}
