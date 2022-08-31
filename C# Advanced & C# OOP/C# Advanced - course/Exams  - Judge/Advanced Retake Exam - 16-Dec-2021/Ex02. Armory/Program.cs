using System;
using System.Text;

namespace Ex02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];
            int sum = 0;
            int officerRow = 0;
            int officerCol = 0;
            bool isOut = false;

            for (int row = 0; row < n; row++)
            {
                char[] datas = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = datas[col];
                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }
           
            string command = Console.ReadLine();
            while (true)
            {
                matrix[officerRow, officerCol] = '-';
                if (command == "up" && officerRow - 1 >= 0)
                {
                    officerRow--;
                }
                else if (command == "down" && officerRow + 1 < n)
                {
                    officerRow++;
                }
                else if (command == "left" && officerCol - 1 >= 0)
                {
                    officerCol--;
                }
                else if (command == "right" && officerCol + 1 < n)
                {
                    officerCol++;
                }
                else
                {
                    isOut = true;
                    break;
                }

                if (Char.IsDigit(matrix[officerRow, officerCol]))
                {
                    sum += matrix[officerRow, officerCol] - 48;
                }
                else if (matrix[officerRow, officerCol] == 'M')
                {
                    matrix[officerRow, officerCol] = '-';
                    int otherMirrorRow = 0;
                    int otherMirrorCol = 0;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (matrix[i,j] == 'M' && i != officerRow && officerCol != j)
                            {
                                otherMirrorRow = i;
                                otherMirrorCol = j;
                            }
                        }
                    }

                    officerRow = otherMirrorRow;
                    officerCol = otherMirrorCol;

                }
                matrix[officerRow, officerCol] = 'A';
                
                if (sum >= 65)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (isOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
           
            Console.WriteLine($"The king paid {sum} gold coins.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static string PrintEnd(char[,] matrix, int sum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Very nice swords, I will come back for more!");
            sb.AppendLine($"The king paid {sum} gold coins.");
            for (int i = 0; i < matrix.GetLength(0) ; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
