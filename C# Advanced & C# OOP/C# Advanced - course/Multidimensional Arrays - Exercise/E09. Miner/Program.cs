using System;
using System.Linq;

namespace E09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRowAndCol = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ");
            int[,] matrix = new int[numberOfRowAndCol, numberOfRowAndCol];
            int countOfCoals = 0;
            int allCoals = 0;
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < numberOfRowAndCol; row++) 
            {
                char[] symbols = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < numberOfRowAndCol; col++)
                {
                    matrix[row, col] = symbols[col];
                    if (matrix[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    { 
                         allCoals++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                switch (command)
                {
                    case "left":
                        if (!(startRow < 0 || startRow > numberOfRowAndCol -1 || startCol -1 < 0 || startCol -1 > numberOfRowAndCol - 1))
                        {
                            if (matrix[startRow, startCol - 1] == 'c')
                            {
                                countOfCoals++;
                                matrix[startRow, startCol - 1] = '*';
                            }
                            else if (matrix[startRow, startCol - 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol-1})");
                                return;
                            }
                            
                            startCol = startCol - 1;

                            if (allCoals == countOfCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                    case "right":
                        if (!(startRow < 0 || startRow > numberOfRowAndCol - 1 || startCol + 1 < 0 || startCol + 1 > numberOfRowAndCol - 1))
                        {
                            if (matrix[startRow, startCol + 1] == 'c')
                            {
                                countOfCoals++;
                                matrix[startRow, startCol + 1] = '*';
                            }
                            else if (matrix[startRow, startCol + 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol + 1})");
                                return;
                            }

                            startCol = startCol + 1;
                            if (allCoals == countOfCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                    case "up":
                        if (!(startRow - 1 < 0 || startRow - 1  > numberOfRowAndCol - 1 || startCol < 0 || startCol > numberOfRowAndCol - 1))
                        {
                            if (matrix[startRow - 1, startCol] == 'c')
                            {
                                countOfCoals++;
                                matrix[startRow - 1, startCol] = '*';
                            }
                            else if (matrix[startRow - 1, startCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow - 1}, {startCol})");
                                return;
                            }

                            startRow = startRow - 1;
                            if (allCoals == countOfCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                    case "down":
                        if (!(startRow + 1 < 0 || startRow + 1 > numberOfRowAndCol - 1 || startCol < 0 || startCol > numberOfRowAndCol - 1))
                        {
                            if (matrix[startRow + 1, startCol] == 'c')
                            {
                                countOfCoals++;
                                matrix[startRow + 1, startCol] = '*';
                            }
                            else if (matrix[startRow + 1, startCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow + 1}, {startCol})");
                                return;
                            }

                            startRow = startRow + 1;
                            if (allCoals == countOfCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;

                }
            }

            Console.WriteLine($"{allCoals - countOfCoals} coals left. ({startRow}, {startCol})");
        }
    }
}
