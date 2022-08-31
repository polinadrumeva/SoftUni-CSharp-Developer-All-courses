using System;

namespace Ex02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;
            bool isWin = false;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = size - 1;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow--;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWin = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        if (playerRow - 1 < 0)
                        {
                            playerRow = size - 1;
                        }
                        else
                        {
                            playerRow--;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        
                        if (playerRow + 1 > size-1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }
                   
                }
                else if (command == "down")
                {
                    if (playerRow + 1 > size-1)
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = 0;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow++;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWin = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        
                        if (playerRow + 1 > size-1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        
                        if (playerRow - 1 < 0)
                        {
                            playerRow = size-1;
                        }
                        else
                        {
                            playerRow--;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }

                }
                else if (command == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol = size -1;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol--;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWin = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        
                        if (playerCol - 1 < 0)
                        {
                            playerCol = size -1;
                        }
                        else
                        {
                            playerCol--;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                       
                        if (playerCol + 1 > size -1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }

                }
                else if (command == "right")
                {
                    if (playerCol + 1 > size -1)
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol = 0;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol++;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWin = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                       
                        if (playerCol + 1 > size - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        
                        if (playerCol - 1 < 0)
                        {
                            playerCol = size -1;
                        }
                        else
                        {
                            playerCol--;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }

                }

            }

            if (isWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
