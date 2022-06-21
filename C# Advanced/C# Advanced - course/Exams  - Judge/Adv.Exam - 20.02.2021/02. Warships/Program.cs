using System;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];
            string[] attacks = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int allFirstShips = 0;
            int allSecondShips = 0;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = data[col];

                    if (matrix[row, col] == '<')
                    {
                        allFirstShips++;
                    }
                    else if (matrix[row, col] == '>')
                    { 
                        allSecondShips++;
                    }
                }
            }

            int totalCountShips = 0;
            int firstShips = 0;
            int secondShips = 0;

            for (int i = 0; i < attacks.Length; i++)
            {
                int[] coordinates = attacks[i].Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int attackRow = coordinates[0];
                int attackCol = coordinates[1];

                if (attackRow < 0 || attackRow > size || attackCol < 0 || attackCol > size)
                {
                    continue;
                }
                else if (matrix[attackRow, attackCol] == '#')
                {
                    matrix[attackRow, attackCol] = 'X';
                    if (attackRow - 1 >= 0 && matrix[attackRow - 1, attackCol] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow - 1, attackCol] = 'X';
                    }
                    if (attackRow - 1 >= 0 && matrix[attackRow - 1, attackCol] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow - 1, attackCol] = 'X';
                    }
                    if (attackRow - 1 >= 0 && attackCol + 1 < size && matrix[attackRow - 1, attackCol + 1] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow - 1, attackCol + 1] = 'X';
                    }
                    if (attackRow - 1 >= 0 && attackCol + 1 < size && matrix[attackRow - 1, attackCol + 1] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow - 1, attackCol + 1] = 'X';
                    }
                    if (attackCol + 1 < size && matrix[attackRow, attackCol + 1] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow, attackCol + 1] = 'X';
                    }
                    if (attackCol + 1 < size && matrix[attackRow, attackCol + 1] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow, attackCol + 1] = 'X';
                    }
                    if (attackRow + 1 < size && attackCol + 1 < size && matrix[attackRow + 1, attackCol + 1] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow + 1, attackCol + 1] = 'X';
                    }
                    if (attackRow + 1 < size && attackCol + 1 < size && matrix[attackRow + 1, attackCol + 1] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow + 1, attackCol + 1] = 'X';
                    }
                    if (attackRow + 1 < size && matrix[attackRow + 1, attackCol] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow + 1, attackCol] = 'X';
                    }
                    if (attackRow + 1 < size && matrix[attackRow + 1, attackCol] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow + 1, attackCol] = 'X';
                    }
                    if (attackRow + 1 < size && attackCol - 1 >= 0 && matrix[attackRow + 1, attackCol - 1] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow + 1, attackCol - 1] = 'X';
                    }
                    if (attackRow + 1 < size && attackCol - 1 >= 0 && matrix[attackRow + 1, attackCol - 1] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow + 1, attackCol - 1] = 'X';
                    }
                    if (attackCol - 1 >= 0 && matrix[attackRow, attackCol - 1] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow, attackCol - 1] = 'X';
                    }
                    if (attackCol - 1 >= 0 && matrix[attackRow, attackCol - 1] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow, attackCol - 1] = 'X';
                    }
                    if (attackRow - 1 >= 0 && attackCol - 1 >= 0 && matrix[attackRow - 1, attackCol - 1] == '>')
                    {
                        allSecondShips--;
                        totalCountShips++;
                        secondShips++;
                        matrix[attackRow - 1, attackCol - 1] = 'X';
                    }
                    if (attackRow - 1 >= 0 && attackCol - 1 >= 0 && matrix[attackRow - 1, attackCol - 1] == '<')
                    {
                        allFirstShips--;
                        totalCountShips++;
                        firstShips++;
                        matrix[attackRow - 1, attackCol - 1] = 'X';
                    }
                }
                else if (matrix[attackRow, attackCol] == '>')
                {
                    allSecondShips--;
                    totalCountShips++;
                    secondShips++;
                    matrix[attackRow, attackCol] = 'X';
                }
                else if (matrix[attackRow, attackCol] == '<')
                {
                    allFirstShips--;
                    totalCountShips++;
                    firstShips++;
                    matrix[attackRow, attackCol] = 'X';
                }
                else if (matrix[attackRow, attackCol] == '*')
                {
                    continue;
                }

                if (allSecondShips == 0 || allFirstShips == 0)
                {
                    break;
                }

            }
            if (allFirstShips == 0)
            { 
                Console.WriteLine($"Player Two has won the game! {totalCountShips} ships have been sunk in the battle.");
            }
            else if (allSecondShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {allFirstShips} ships left. Player Two has {allSecondShips} ships left.");
            }
        
        }
    }
}
