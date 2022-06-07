using System;
using System.Linq;

namespace AE06._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int divisibleNumber = int.Parse(Console.ReadLine());

            numbers.Reverse();
            Predicate<int> isDivisible = x => x % divisibleNumber == 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (isDivisible(numbers[i]))
                {
                    numbers.Remove(numbers[i]);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));


        }
    }
}
