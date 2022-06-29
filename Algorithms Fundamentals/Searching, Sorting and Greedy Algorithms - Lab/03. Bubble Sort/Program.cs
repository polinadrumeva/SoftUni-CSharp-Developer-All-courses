using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BubbleSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            int sortedCount = 0;
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < numbers.Length - sortedCount; j++)
                {
                    var i = j - 1;
                    if (numbers[i] > numbers[j])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
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
