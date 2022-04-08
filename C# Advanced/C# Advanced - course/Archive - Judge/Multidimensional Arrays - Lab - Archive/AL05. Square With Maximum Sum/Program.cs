using System;
using System.Linq;

namespace AL05._Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = parameters[0];
            int cols = parameters[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int sum = int.MinValue;
            int[] rowsParams = new int[2];
            int[] colsParams = new int[2];

            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < cols - 1; k++)
                {
                    int currentSum = matrix[i, k] + matrix[i, k + 1] + matrix[i + 1, k] + matrix[i + 1, k + 1];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        rowsParams[0] = matrix[i, k];
                        rowsParams[1] = matrix[i, k + 1];
                        colsParams[0] = matrix[i + 1, k];
                        colsParams[1] = matrix[i + 1, k + 1];

                    }
                }
            }

            Console.WriteLine(string.Join(" ", rowsParams));
            Console.WriteLine(string.Join(" ", colsParams));
            Console.WriteLine(sum);
        }
    }
}
