using System;
using System.Linq;

namespace E06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[numberOfRows][];

            // populating the matrix
            for (int i = 0; i < numberOfRows; i++)
            {
                int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jagged[i] = new int[data.Length];
                for (int eachRow = 0; eachRow < data.Length; eachRow++)
                {
                    jagged[i][eachRow] = data[eachRow];
                }
            }

            // analyzing the matrix

            for (int outsideRow = 0; outsideRow < numberOfRows - 1; outsideRow++)
            {
                if (jagged[outsideRow].Length == jagged[outsideRow + 1].Length)
                {
                    for (int i = outsideRow; i <= outsideRow + 1; i++)
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] *= 2;
                        }
                    }
                }
                else
                {
                    for (int i = outsideRow; i <= outsideRow + 1; i++)
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] /= 2;
                        }
                    }
                }
            }

            // manipulation the element of the matrix

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" ");
                if (cmdArg[0] == "Add")
                {
                    int row = int.Parse(cmdArg[1]);
                    int column = int.Parse(cmdArg[2]);
                    int value = int.Parse(cmdArg[3]);
                    if (row >= 0 && row < numberOfRows && column >= 0 && column < jagged[row].Length)
                    {
                        jagged[row][column] += value;
                    }
                }
                else if (cmdArg[0] == "Subtract")
                {
                    int row = int.Parse(cmdArg[1]);
                    int column = int.Parse(cmdArg[2]);
                    int value = int.Parse(cmdArg[3]);

                    if (row >= 0 && row < numberOfRows && column >= 0 && column < jagged[row].Length)
                    {
                        jagged[row][column] -= value;
                    }
                }

            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int each = 0; each < jagged[row].Length; each++)
                {
                    Console.Write(jagged[row][each] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
