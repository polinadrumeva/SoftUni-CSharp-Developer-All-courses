using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            InsertionSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var j = i;
                while (j > 0 && numbers[j] < numbers[j-1])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
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
