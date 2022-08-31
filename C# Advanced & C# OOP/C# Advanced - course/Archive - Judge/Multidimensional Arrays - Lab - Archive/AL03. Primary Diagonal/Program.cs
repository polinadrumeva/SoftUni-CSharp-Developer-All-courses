using System;
using System.Linq;

namespace AL03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquare = int.Parse(Console.ReadLine());

            int[,] square = new int[sizeOfSquare, sizeOfSquare];

            for (int i = 0; i < sizeOfSquare; i++)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int k = 0; k < sizeOfSquare; k++)
                {
                    square[i, k] = numbers[k];
                }
            }

            int sum = 0;

            for (int i = 0; i < sizeOfSquare; i++)
            {
                sum += square[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
