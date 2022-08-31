using System;
using System.Linq;

namespace AL06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int square = int.Parse(Console.ReadLine());

            int[,] matrix = new int[square, square];

            for (int i = 0; i < square; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < square; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(" ");
                string typeCommand = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);
                if (row > square - 1 || col > square - 1 || row < 0 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (typeCommand == "Add")
                {
                    matrix[row, col] += value;
                }
                else if (typeCommand == "Subtract")
                {
                    matrix[row, col] -= value;
                }
            }

            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
