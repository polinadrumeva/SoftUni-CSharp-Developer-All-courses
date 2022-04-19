using System;
using System.Linq;

namespace AE03._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = parameters[0];
            int cols = parameters[1];
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] symbols = Console.ReadLine().Trim().Split(' ').ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = symbols[j];
                }
            }

            int match = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i,j] == matrix[i, j+1] && matrix[i+1, j] == matrix[i+1, j+1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        match++;
                    }
                }
            }

            Console.WriteLine(match);
        }
    }
}
