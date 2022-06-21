using System;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());   
            char[][] maze = new char[rows][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < rows; row++)
            { 
                char[] data = Console.ReadLine().ToCharArray();
                maze[row] = new char[data.Length];
                for (int col = 0; col < data.Length; col++)
                { 
                    maze[row][col] = data[col];
                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col; 
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                string direction = command[0];
                int rowEnemy = int.Parse(command[1]);
                int colEnemy = int.Parse(command[2]);

                maze[rowEnemy][colEnemy] = 'B';
                lives--;
                if (direction == "W")
                {
                    if (marioRow - 1 < 0)
                    {
                        continue;
                    }
                    else if (maze[marioRow - 1][marioCol] == 'B')
                    {
                        lives -= 2;
                        maze[marioRow][marioCol] = '-';

                        if (lives <= 0)
                        {
                            marioRow--;
                            maze[marioRow][marioCol] = 'X';
                            break;
                        }
                        else
                        {
                            marioRow--;
                            maze[marioRow][marioCol] = 'M';
                        }
                    }
                    else if (maze[marioRow - 1][marioCol] == 'P')
                    {
                        maze[marioRow][marioCol] = '-';
                        marioRow--;
                        maze[marioRow][marioCol] = '-';
                        break;
                    }
                    else
                    {
                        maze[marioRow][marioCol] = '-';
                        marioRow--;
                        maze[marioRow][marioCol] = 'M';
                    }
                }
                else if (direction == "S")
                {
                    if (marioRow + 1 > rows - 1)
                    {
                        continue;
                    }
                    else if (maze[marioRow + 1][marioCol] == 'B')
                    {
                        lives -= 2;
                        maze[marioRow][marioCol] = '-';
                        if (lives <= 0)
                        {
                            marioRow++;
                            maze[marioRow][marioCol] = 'X';
                            break;
                        }
                        else
                        {
                            marioRow++;
                            maze[marioRow][marioCol] = '-';
                        }
                    }
                    else if (maze[marioRow + 1][marioCol] == 'P')
                    {
                        maze[marioRow][marioCol] = '-';
                        marioRow++;
                        maze[marioRow][marioCol] = '-';
                        break;
                    }
                    else
                    {
                        maze[marioRow][marioCol] = '-';
                        marioRow++;
                        maze[marioRow][marioCol] = 'M';
                    }
                }
                else if (direction == "A")
                {
                    if (marioCol - 1 < 0)
                    {
                        continue;
                    }
                    else if (maze[marioRow][marioCol -1] == 'B')
                    {
                        lives -= 2;
                        maze[marioRow][marioCol] = '-';
                        if (lives <= 0)
                        {
                            marioCol--;
                            maze[marioRow][marioCol] = 'X';
                            break;
                        }
                        else
                        {
                            marioCol--;
                            maze[marioRow][marioCol - 1] = '-';
                        }
                    }
                    else if (maze[marioRow][marioCol - 1] == 'P')
                    {
                        maze[marioRow][marioCol] = '-';
                        marioCol--;
                        maze[marioRow][marioCol] = '-';
                        break;
                    }
                    else
                    {
                        maze[marioRow][marioCol] = '-';
                        marioCol--;
                        maze[marioRow][marioCol] = 'M';
                    }
                }
                else if (direction == "D")
                {
                    if (marioCol + 1 > maze[marioRow].Length - 1 )
                    {
                        continue;
                    }
                    else if (maze[marioRow][marioCol + 1] == 'B')
                    {
                        lives -= 2;
                        maze[marioRow][marioCol] = '-';
                        if (lives <= 0)
                        {
                            marioCol++;
                            maze[marioRow][marioCol] = 'X';
                            break;
                        }
                        else
                        {
                            marioCol++;
                            maze[marioRow][marioCol] = '-';
                        }
                    }
                    else if (maze[marioRow][marioCol + 1] == 'P')
                    {
                        maze[marioRow][marioCol] = '-';
                        marioCol++;
                        maze[marioRow][marioCol] = '-';
                        break;
                    }
                    else
                    {
                        maze[marioRow][marioCol] = '-';
                        marioCol++;
                        maze[marioRow][marioCol] = 'M';
                    }
                }
            }


            if (lives <= 0)
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    Console.Write(maze[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
