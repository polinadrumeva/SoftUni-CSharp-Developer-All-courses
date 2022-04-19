using System;
using System.Linq;

namespace AE02._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int square = int.Parse(Console.ReadLine());
            int[,] matrix = new int[square, square];

            for (int i = 0; i < square; i++)
            {
                int[] numbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < square; j++)
                {
                    matrix[i,j] = numbers[j];
                }
            }

            long primarySum = 0;
            long secondarySum = 0;

            for (int i = 0; i < square; i++)
            { 
                primarySum += matrix[i,i];
            }

            int count = 0;
                for (int j = square - 1; j >= 0; j--)
                {
                    secondarySum += matrix[count, j];
                    count++;
                }

            long difference = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(difference);

        }
    }
}
