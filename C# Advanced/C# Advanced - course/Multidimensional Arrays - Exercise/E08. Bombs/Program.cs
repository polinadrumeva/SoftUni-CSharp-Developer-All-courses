using System;
using System.Linq;

namespace E08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberForRowAndCol = int.Parse(Console.ReadLine());
            int[,] matrix = new int[numberForRowAndCol, numberForRowAndCol];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string[] bombs = Console.ReadLine().Split(" ").ToArray();
            for (int i = 0; i < bombs.Length; i++)
            {
                string[] eachBomb = bombs[i].Split(",");
                int bombRow = int.Parse(eachBomb[0]);
                int bombCol = int.Parse(eachBomb[1]);

                int bombValue = matrix[bombRow, bombCol];
                matrix[bombRow, bombCol] = 0;

                if (!(bombRow - 1 < 0 || bombCol - 1 < 0 || bombRow - 1 > matrix.GetLength(0) - 1 || bombCol -1 > matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow - 1, bombCol - 1] == 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] = 0;
                    }
                    else if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombValue;
                    }
                }
                
                if (!(bombRow - 1 < 0 || bombCol < 0 || bombRow - 1 > matrix.GetLength(0)-1 || bombCol > matrix.GetLength(1) -1))
                {
                    if (matrix[bombRow - 1, bombCol] == 0)
                    {
                        matrix[bombRow - 1, bombCol] = 0;
                    }
                    else if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bombValue;
                    }
                }
                
                if (!(bombRow - 1 < 0 || bombCol + 1 < 0 || bombRow - 1 > matrix.GetLength(0) - 1 || bombCol + 1> matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow - 1, bombCol + 1] == 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] = 0;
                    }
                    else if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombValue;
                    }
                }
                
                if (!(bombRow < 0 || bombCol - 1 < 0 || bombRow > matrix.GetLength(0) - 1 || bombCol - 1 > matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow, bombCol - 1] == 0)
                    {
                        matrix[bombRow, bombCol - 1] = 0;
                    }
                    else if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombValue;
                    }
                }
                
                if (!(bombRow < 0 || bombCol + 1 < 0 || bombRow > matrix.GetLength(0) - 1 || bombCol + 1 > matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow, bombCol + 1] == 0)
                    {
                        matrix[bombRow, bombCol + 1] = 0;
                    }
                    else if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bombValue;
                    }
                }
                
                if (!(bombRow + 1 < 0 || bombCol - 1 < 0 || bombRow + 1 > matrix.GetLength(0) - 1 || bombCol - 1 > matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow + 1, bombCol - 1] == 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] = 0;
                    }
                    else if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombValue;
                    }
                }
                
                if (!(bombRow + 1 < 0 || bombCol < 0 || bombRow + 1 > matrix.GetLength(0) - 1 || bombCol > matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow + 1, bombCol] == 0)
                    {
                        matrix[bombRow + 1, bombCol] = 0;
                    }
                    else if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bombValue;
                    }
                }
                
                if (!(bombRow + 1 < 0 || bombCol + 1 < 0 || bombRow + 1 > matrix.GetLength(0) - 1 || bombCol + 1 > matrix.GetLength(1) - 1))
                {
                    if (matrix[bombRow + 1, bombCol + 1] == 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] = 0;
                    }
                    else if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombValue;
                    }
                }
                
            }

            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row,col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}

