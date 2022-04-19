using System;
using System.Collections.Generic;
using System.Linq;

namespace AE04._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = parameters[0];
            int cols = parameters[1];
            int[,] matrix = new int[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = numbers[j];
                }
            }

            int sum = int.MinValue;
            int[] firstLine = new int[3];
            int[] secondLine = new int[3];
            int[] thirdLine = new int[3];   

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int currentSum = matrix[i,j] + matrix[i, j+1] + matrix[i, j+2] + matrix[i+1, j] + matrix[i+1, j+1] + matrix[i+1, j+2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        firstLine[0] = matrix[i, j];
                        firstLine[1] = matrix[i, j + 1];
                        firstLine[2] = matrix[i, j + 2];
                        secondLine[0] = matrix[i + 1, j];
                        secondLine[1] = matrix[i + 1, j + 1];
                        secondLine[2] = matrix[i + 1, j + 2];
                        thirdLine[0] = matrix[i + 2, j];
                        thirdLine[1] = matrix[i + 2, j + 1];
                        thirdLine[2] = matrix[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine(string.Join(" ", firstLine));
            Console.WriteLine(string.Join(" ", secondLine));
            Console.WriteLine(string.Join(" ", thirdLine));
        }
    }
}
