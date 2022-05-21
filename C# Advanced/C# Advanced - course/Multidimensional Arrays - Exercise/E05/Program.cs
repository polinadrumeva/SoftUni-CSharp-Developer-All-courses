using System;
using System.Linq;

namespace E05._Sn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            char[] snake = Console.ReadLine().ToCharArray();
            int count = 0;
            int rows = 0;

            for (int row = 0; row < matrix.GetLength(0); row += 2)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[count];
                    count++;
                    if (count == snake.Length)
                    {
                        count = 0;
                    }
                    rows = row;
                    if (col == matrix.GetLength(1) - 1 && row < matrix.GetLength(0) - 1)
                    {
                        row++;
                        for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                        {
                            matrix[row, cols] = snake[count];
                            count++;
                            if (count == snake.Length)
                            {
                                count = 0;
                            }
                        }
                    }
                    else if (col == matrix.GetLength(1) - 1 && row == matrix.GetLength(0) - 1)
                    {
                        break;
                    }
                }
                row = rows;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
