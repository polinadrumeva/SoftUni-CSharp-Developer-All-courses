using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            List<char> branches = new List<char>();
            int currentRow = 0;
            int currentCol = 0;
            int countLeft = 0;
            int allBranch = 0;
            int checkBranch = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = data[col];
                    if (pond[row, col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (Char.IsLower(pond[row, col]))
                    {
                        allBranch++;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "up":
                        if (currentRow - 1 < 0)
                        {
                            if (branches.Count != 0)
                            {
                                branches.RemoveAt(branches.Count-1);
                            }
                        }
                        else if (Char.IsLower(pond[currentRow - 1, currentCol]))
                        {
                            branches.Add(pond[currentRow - 1, currentCol]);
                            checkBranch++;
                            pond[currentRow, currentCol] = '-';
                            currentRow--;
                            pond[currentRow, currentCol] = 'B';
                        }
                        else if (pond[currentRow - 1, currentCol] == 'F')
                        {
                            pond[currentRow - 1, currentCol] = '-';
                            pond[currentRow, currentCol] = '-';
                            currentRow--;

                            if (currentRow == 0)
                            {
                                currentRow = pond.GetLength(0) - 1;
                                if (Char.IsLower(pond[currentRow, currentCol]))
                                {
                                    branches.Add(pond[currentRow, currentCol]);
                                    checkBranch++;
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    pond[currentRow, currentCol] = 'B';
                                }

                            }
                            else
                            {
                                currentRow = 0;
                                pond[currentRow, currentCol] = 'B';
                            }

                        }
                        break;
                    case "down":
                        if (currentRow + 1 > pond.GetLength(0) - 1)
                        {
                            if (branches.Count != 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                        }
                        else if (Char.IsLower(pond[currentRow + 1, currentCol]))
                        {
                            branches.Add(pond[currentRow + 1, currentCol]);
                            checkBranch++;
                            pond[currentRow, currentCol] = '-';
                            currentRow++;
                            pond[currentRow, currentCol] = 'B';
                        }
                        else if (pond[currentRow + 1, currentCol] == 'F')
                        {
                            pond[currentRow + 1, currentCol] = '-';
                            pond[currentRow, currentCol] = '-';
                            currentRow++;

                            if (currentRow == pond.GetLength(0) - 1)
                            {
                                currentRow = 0;
                                if (Char.IsLower(pond[currentRow, currentCol]))
                                {
                                    branches.Add(pond[currentRow, currentCol]);
                                    checkBranch++;
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {
                                currentRow = pond.GetLength(0) - 1;
                                pond[currentRow, currentCol] = 'B';
                            }
                        }
                        break;
                    case "left":
                        if (currentCol - 1 < 0)
                        {
                            if (branches.Count != 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                        }
                        else if (Char.IsLower(pond[currentRow, currentCol - 1]))
                        {
                            branches.Add(pond[currentRow, currentCol - 1]);
                            checkBranch++;
                            pond[currentRow, currentCol] = '-';
                            currentCol--;
                            pond[currentRow, currentCol] = 'B';
                        }
                        else if (pond[currentRow, currentCol - 1] == 'F')
                        {
                            pond[currentRow, currentCol - 1] = '-';
                            pond[currentRow, currentCol] = '-';
                            currentRow--;

                            if (currentRow == 0)
                            {
                                currentRow = pond.GetLength(1) - 1;
                                if (Char.IsLower(pond[currentRow, currentCol]))
                                {
                                    branches.Add(pond[currentRow, currentCol]);
                                    checkBranch++;
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {
                                currentRow = 0;
                                pond[currentRow, currentCol] = 'B';
                            }
                        }
                        break;
                    case "right":
                        if (currentCol + 1 > pond.GetLength(1)-1)
                        {
                            if (branches.Count != 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                        }
                        else if (Char.IsLower(pond[currentRow, currentCol + 1]))
                        {
                            branches.Add(pond[currentRow, currentCol + 1]);
                            checkBranch++;
                            pond[currentRow, currentCol] = '-';
                            currentCol++;
                            pond[currentRow, currentCol] = 'B';
                        }
                        else if (pond[currentRow, currentCol + 1] == 'F')
                        {
                            pond[currentRow, currentCol + 1] = '-';
                            pond[currentRow, currentCol] = '-';
                            currentRow++;

                            if (currentRow == pond.GetLength(1) - 1)
                            {
                                currentRow = 0;
                                if (Char.IsLower(pond[currentRow, currentCol]))
                                {
                                    branches.Add(pond[currentRow, currentCol]);
                                    checkBranch++;
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {
                                currentRow = pond.GetLength(1) - 1;
                                pond[currentRow, currentCol] = 'B';
                            }
                        }
                        break;
                }

                if (allBranch == checkBranch)
                {
                    break;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Char.IsLower(pond[i, j]))
                    {
                        countLeft++;
                    }
                }
            }

            if (countLeft != 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countLeft} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
