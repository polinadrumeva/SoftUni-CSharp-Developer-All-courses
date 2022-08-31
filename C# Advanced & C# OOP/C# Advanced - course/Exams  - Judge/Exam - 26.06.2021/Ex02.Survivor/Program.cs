using System;

namespace Ex02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            string[][] matrix = new string[numberOfRows][];
            int collectedTokens = 0;
            int opponentTokens = 0;

            for (int row = 0; row < numberOfRows; row++)
            {
                string[] data = Console.ReadLine().Split(" ");
                matrix[row] = new string[data.Length];
                for (int col = 0; col < data.Length; col++)
                {
                    matrix[row][col] = data[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmdArg = command.Split(" ");
                string move = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                if (move == "Find")
                {
                    if (Validation(matrix, numberOfRows, row, col))
                    {
                        if (matrix[row][col] == "T")
                        {
                            collectedTokens++;
                            matrix[row][col] = "-";
                        }
                    }
                }
                else if (move == "Opponent")
                {
                    string direction = cmdArg[3];
                    if (Validation(matrix, numberOfRows, row, col))
                    {
                        if (matrix[row][col] == "T")
                        {
                            opponentTokens++;
                            matrix[row][col] = "-";
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (direction == "up")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (row - 1 >= 0 )
                            {
                                row--;
                                if (matrix[row][col] == "T")
                                {
                                    opponentTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (row + 1 >= 0)
                            {
                                row++;
                                if (matrix[row][col] == "T")
                                {
                                    opponentTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (col - 1 >= 0)
                            {
                                col--;
                                if (matrix[row][col] == "T")
                                {
                                    opponentTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (col + 1 < matrix[row].Length)
                            {
                                col++;
                                if (matrix[row][col] == "T")
                                {
                                    opponentTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }


        public static bool Validation(string[][] matrix,int numberOfRows, int row, int col)
        {
            if (row >= 0 && row < numberOfRows && col >= 0 && col < matrix[row].Length )
            {
                return true;
            }

            return false;
        }
    }
}
