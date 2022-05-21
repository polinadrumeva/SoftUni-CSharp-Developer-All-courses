using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dataFormatrix = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string[,] matrix = new string[dataFormatrix[0], dataFormatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(" ");
                if (cmdArgs.Length != 5 || cmdArgs[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else if (cmdArgs[0] == "swap")
                {
                    if ((int.Parse(cmdArgs[1]) < 0 || int.Parse(cmdArgs[1]) > matrix.GetLength(0) - 1) || (int.Parse(cmdArgs[2]) < 0 || int.Parse(cmdArgs[2]) > matrix.GetLength(1) - 1)
                        || (int.Parse(cmdArgs[3]) < 0 || int.Parse(cmdArgs[3]) > matrix.GetLength(0) - 1) || (int.Parse(cmdArgs[4]) < 0 || int.Parse(cmdArgs[4]) > matrix.GetLength(1) - 1))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    else
                    {
                        string last = matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])];
                        matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])] = matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])];
                        matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])] = last;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }

        }
    }
}
