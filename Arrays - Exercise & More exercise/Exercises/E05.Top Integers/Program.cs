using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isTopInteger = true;
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    if (numbers[i] <= numbers[k])
                    {
                        isTopInteger = false;
                    }
                }

                if (isTopInteger)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}