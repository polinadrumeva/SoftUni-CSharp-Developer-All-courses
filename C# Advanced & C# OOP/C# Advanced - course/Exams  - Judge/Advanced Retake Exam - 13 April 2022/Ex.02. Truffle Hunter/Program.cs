using System;

namespace Ex._02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows, rows];
            int countBlack = 0;
            int countWhite = 0;
            int countSummer = 0;
            int countBoar = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] data = Console.ReadLine().Split(" ");
                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArg = command.Split(" ");
                string action = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                switch (action)
                {
                    case "Collect":
                        if (matrix[row, col] == "B")
                        {
                            countBlack++;
                            matrix[row, col] = "-";
                        }
                        else if (matrix[row, col] == "S")
                        {
                            countSummer++;
                            matrix[row, col] = "-";
                        }
                        else if (matrix[row, col] == "W")
                        {
                            countWhite++;
                            matrix[row, col] = "-";
                        }
                        break;
                    case "Wild_Boar":
                        string direction = cmdArg[3];
                        switch (direction)
                        {
                            case"up":
                                for (int i = row; i >= 0; i -= 2)
                                {
                                    if (matrix[i, col] == "B" || matrix[i, col] == "S" || matrix[i, col] == "W")
                                    {
                                        countBoar++;
                                        matrix[i, col] = "-";
                                    }
                                }
                                break;

                            case"down":
                                for (int i = row; i < rows; i += 2)
                                {
                                    if (matrix[i, col] == "B" || matrix[i, col] == "S" || matrix[i, col] == "W")
                                    {
                                        countBoar++;
                                        matrix[i, col] = "-";
                                    }
                                }
                                break;

                            case "right":
                                for (int i = col; i < rows; i += 2)
                                {
                                    if (matrix[row, i] == "B" || matrix[row, i] == "S" || matrix[row, i] == "W")
                                    {
                                        countBoar++;
                                        matrix[row, i] = "-";
                                    }
                                }
                                break;

                            case "left":
                                for (int i = col; i >= 0; i -= 2)
                                {
                                    if (matrix[row, i] == "B" || matrix[row, i] == "S" || matrix[row, i] == "W")
                                    {
                                        countBoar++;
                                        matrix[row, i] = "-";
                                    }
                                }
                                break;
                        }
                        break;

                }
               
            }

            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {countBoar} truffles.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else 
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    
                }
                Console.WriteLine();
            }
                
        }

    }
}
