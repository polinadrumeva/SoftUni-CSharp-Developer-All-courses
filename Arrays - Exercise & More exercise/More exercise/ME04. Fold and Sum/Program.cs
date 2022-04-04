using System;
using System.Linq;

namespace ME04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] firstNumbers = new int[numbers.Length / 4];
            int[] lastNumbers = new int[numbers.Length / 4];
            int[] middleNumbers = new int[numbers.Length / 2];
            int[] sums = new int[numbers.Length / 2];

            int i = 0;
            int l = 0;
            int k = 0;
            while (i < numbers.Length / 4)
            {
                firstNumbers[i] = numbers[i];
                i++;
            }
            while (i == numbers.Length / 4 || i < numbers.Length - numbers.Length/4)
            {
                middleNumbers[l] = numbers[i];
                l++;
                i++;
            }
            while (i == numbers.Length - numbers.Length /4 || i < numbers.Length)
            {
                lastNumbers[k] = numbers[i];
                k++;
                i++;
            }

            Array.Reverse(firstNumbers);
            Array.Reverse(lastNumbers);
            i = 0;
            int m = 0;
            int n = 0;

            while (i < sums.Length)
            {
                if (i < sums.Length /2)
                {
                    sums[i] = firstNumbers[m] + middleNumbers[m];
                    i++;
                    m++;
                }
                else if (i > sums.Length /2 || i < sums.Length)
                {
                    sums[i] = lastNumbers[n] + middleNumbers[m];
                    i++;
                    n++;
                    m++;
                }
                
            }

            Console.WriteLine(string.Join(" ", sums));
        }
    }
}
