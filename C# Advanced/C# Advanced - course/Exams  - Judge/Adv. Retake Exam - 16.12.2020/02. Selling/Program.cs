using System;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int myPositionRow = 0;
            int myPositionCol = 0;
            int collectSum = 0;
            bool isOut = false;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'S')
                    {
                        myPositionRow = row;
                        myPositionCol = col;
                    }
                }
            }

            string command = Console.ReadLine();    
            while (true)
            {
                if (command == "up")
                {
                    matrix[myPositionRow, myPositionCol] = '-';
                    if (myPositionRow - 1 < 0)
                    {
                        isOut = true;
                        break;
                    }
                    else if (matrix[myPositionRow - 1, myPositionCol] == 'O')
                    {
                        int tunelRow = 0;
                        int tunelCol = 0;
                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && row != myPositionRow - 1)
                                {
                                    tunelRow = row;
                                    tunelCol = col;

                                }
                            }
                        }

                        matrix[myPositionRow - 1, myPositionCol] = '-';
                        myPositionRow = tunelRow;
                        myPositionCol = tunelCol;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                    else if (Char.IsDigit(matrix[myPositionRow - 1, myPositionCol]))
                    {
                        collectSum += (int)matrix[myPositionRow - 1, myPositionCol] - 48;
                        myPositionRow--;
                        matrix[myPositionRow, myPositionCol] = 'S';

                    }
                    else
                    {
                        myPositionRow--;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                }
                else if (command == "down")
                {
                    matrix[myPositionRow, myPositionCol] = '-';
                    if (myPositionRow + 1 > size - 1)
                    {
                        isOut = true;
                        break;
                    }
                    else if (matrix[myPositionRow + 1, myPositionCol] == 'O')
                    {
                        int tunelRow = 0;
                        int tunelCol = 0;
                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && row != myPositionRow + 1)
                                {
                                    tunelRow = row;
                                    tunelCol = col;

                                }
                            }
                        }

                        matrix[myPositionRow + 1, myPositionCol] = '-';
                        myPositionRow = tunelRow;
                        myPositionCol = tunelCol;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                    else if (Char.IsDigit(matrix[myPositionRow + 1, myPositionCol]))
                    {
                        collectSum += (int)matrix[myPositionRow + 1, myPositionCol] - 48;
                        myPositionRow++;
                        matrix[myPositionRow, myPositionCol] = 'S';

                    }
                    else
                    {
                        myPositionRow++;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                }
                else if (command == "left")
                {
                    matrix[myPositionRow, myPositionCol] = '-';
                    if (myPositionCol - 1 < 0)
                    {
                        isOut = true;
                        break;
                    }
                    else if (matrix[myPositionRow, myPositionCol -1] == 'O')
                    {
                        int tunelRow = 0;
                        int tunelCol = 0;
                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && col != myPositionCol - 1)
                                {
                                    tunelRow = row;
                                    tunelCol = col;

                                }
                            }
                        }

                        matrix[myPositionRow, myPositionCol-1] = '-';
                        myPositionRow = tunelRow;
                        myPositionCol = tunelCol;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                    else if (Char.IsDigit(matrix[myPositionRow, myPositionCol-1]))
                    {
                        collectSum += (int)matrix[myPositionRow, myPositionCol-1] - 48;
                        myPositionCol--;
                        matrix[myPositionRow, myPositionCol] = 'S';

                    }
                    else
                    {
                        myPositionCol--;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                }
                else if (command == "right")
                {
                    matrix[myPositionRow, myPositionCol] = '-';
                    if (myPositionCol + 1 > size - 1)
                    {
                        isOut = true;
                        break;
                    }
                    else if (matrix[myPositionRow, myPositionCol + 1] == 'O')
                    {
                        int tunelRow = 0;
                        int tunelCol = 0;
                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && col != myPositionCol + 1)
                                {
                                    tunelRow = row;
                                    tunelCol = col;

                                }
                            }
                        }

                        matrix[myPositionRow, myPositionCol + 1] = '-';
                        myPositionRow = tunelRow;
                        myPositionCol = tunelCol;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                    else if (Char.IsDigit(matrix[myPositionRow, myPositionCol + 1]))
                    {
                        collectSum += (int)matrix[myPositionRow, myPositionCol + 1] - 48;
                        myPositionCol++;
                        matrix[myPositionRow, myPositionCol] = 'S';

                    }
                    else
                    {
                        myPositionCol++;
                        matrix[myPositionRow, myPositionCol] = 'S';
                    }
                }

                if (collectSum >= 50)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (collectSum >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {collectSum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
