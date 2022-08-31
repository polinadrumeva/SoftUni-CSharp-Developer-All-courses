using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int vankoRow = 0;
            int vankoCol = 0;
            char[,] matrix = new char[size,size];
            int holes = 0;
            int countOfRods = 0;
            bool isElectroshocked = false;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray(); 
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = data[col];
                    if (matrix[row,col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col; 
                    }
                }
            }
            matrix[vankoRow, vankoCol] = '*';
            holes++;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                 matrix[vankoRow, vankoCol] = '*';
                
                if (command == "up" && vankoRow - 1 >= 0)
                {
                    vankoRow--;
                }
                else if (command == "down" && vankoRow + 1 < size)
                {
                    vankoRow++;
                }
                else if (command == "left" && vankoCol - 1 >= 0)
                {
                    vankoCol--;
                }
                else if (command == "right" && vankoCol + 1 < size)
                { 
                    vankoCol++;
                }
                else
                {
                    matrix[vankoRow, vankoCol] = 'V';
                    continue;
                }

                if (matrix[vankoRow, vankoCol] == 'R')
                {
                    if (command == "up")
                    {
                        vankoRow++;
                    }
                    else if (command == "down")
                    {
                        vankoRow--;
                    }
                    else if (command == "left")
                    {
                        vankoCol++;
                    }
                    else if (command == "right")
                    {
                        vankoCol--;
                    }
                    countOfRods++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[vankoRow, vankoCol] == 'C')
                {
                    matrix[vankoRow, vankoCol] = 'E';
                    isElectroshocked = true;
                    holes++;
                    break;
                }
                else if (matrix[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }
                else 
                {
                    holes++;
                }

                matrix[vankoRow, vankoCol] = 'V';

            }

            if (isElectroshocked)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {countOfRods} rod(s).");
            }

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
