using System;

namespace _02._Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;
            int flowers = 0;
            bool isOut = false;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;

                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';

                if (command == "up" && beeRow - 1 >= 0)
                {
                    beeRow--;
                }
                else if (command == "down" && beeRow + 1 < size)
                {
                    beeRow++;
                }
                else if (command == "left" && beeCol - 1 >= 0)
                {
                    beeCol--;
                }
                else if (command == "right" && beeCol + 1 < size)
                {
                    beeCol++;
                }
                else
                {
                    isOut = true;
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowers++;
                    matrix[beeRow, beeCol] = 'B';
                }
                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    if (command == "up" && beeRow - 1 >= 0)
                    {
                        beeRow--;
                    }
                    else if (command == "down" && beeRow + 1 < size)
                    {
                        beeRow++;
                    }
                    else if (command == "left" && beeCol - 1 >= 0)
                    {
                        beeCol--;
                    }
                    else if (command == "right" && beeCol + 1 < size)
                    {
                        beeCol++;
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                    matrix[beeRow, beeCol] = 'B';

                }
                else
                {
                    matrix[beeRow, beeCol] = 'B';
                }

            }

            if (isOut)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowers < 5 )
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
