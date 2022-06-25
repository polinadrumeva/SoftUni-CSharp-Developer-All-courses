using System;

namespace _02._Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int snakeRow = 0;
            int snakeColumn = 0;
            int food = 0;
            bool isOut = false;
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row; 
                        snakeColumn = col;  
                    }
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                matrix[snakeRow, snakeColumn] = '.';
                if (command == "up" && snakeRow - 1 >= 0)
                { 
                    snakeRow--;
                }
                else if (command == "down" && snakeRow + 1 < size)
                {
                    snakeRow++;
                }
                else if (command == "left" && snakeColumn - 1 >= 0)
                {
                    snakeColumn--;
                }
                else if (command == "right" && snakeColumn + 1 < size)
                {
                    snakeColumn++;
                }
                else
                {
                    isOut = true;
                    break;
                }

                if (matrix[snakeRow, snakeColumn] == '*')
                {
                    food++;
                }
                else if (matrix[snakeRow, snakeColumn] == 'B')
                {
                    int borrowRow = 0;
                    int borrowColumn = 0;
                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (matrix[row, col] == 'B' && snakeRow != row && snakeColumn != col)
                            {
                                borrowRow = row;
                                borrowColumn = col;
                            }
                        }
                    }

                    matrix[snakeRow, snakeColumn] = '.';
                    snakeRow = borrowRow;
                    snakeColumn = borrowColumn;

                }
                
                matrix[snakeRow, snakeColumn] = 'S';

                if (food >= 10)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
            }
            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {food}");

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
