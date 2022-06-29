using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Selection(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Selection(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }

                Swap(numbers, i, min);
            }

            
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int current = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = current;
        }
    }
}
