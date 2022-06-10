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
            int kingRow = 0;
            int kingCol = 0;
            bool isOut = false;

            for (int row = 0; row < n; row++)
            {
                char[] datas = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = datas[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        kingRow = row;
                        kingCol = col;
                    }
                }
            }
            string command = Console.ReadLine();
            while (true)
            {
                switch (command)
                {
                    case "up":
                        if (kingRow - 1 < 0)
                        {
                            matrix[kingRow, kingCol] = '-';
                            isOut = true;
                        }
                        else if (Char.IsDigit(matrix[kingRow - 1, kingCol]))
                        {
                            sum += matrix[kingRow - 1, kingCol]-48;
                            matrix[kingRow, kingCol] = '-';
                            kingRow -= 1;
                            matrix[kingRow, kingCol] = 'A';
                            if (sum >= 65)
                            {
                                Console.WriteLine(PrintEnd(matrix, sum));
                                return;
                            }
                        }
                        else if (matrix[kingRow - 1, kingCol] == 'M')
                        {

                            int mirrorRow = 0;
                            int mirrorCol = 0;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (i != kingRow - 1 && j != kingCol && matrix[kingRow -1, kingCol] == matrix[i, j])
                                    {
                                        mirrorRow = i;
                                        mirrorCol = j;
                                    }
                                }
                            }

                            matrix[kingRow, kingCol] = '-';
                            matrix[kingRow-1, kingCol] = '-';
                            kingRow = mirrorRow;
                            kingCol = mirrorCol;
                            matrix[kingRow, kingCol] = 'A';

                        }
                        
                        break;
                    case "down":
                        if (kingRow + 1 > matrix.GetLength(0) - 1)
                        {
                            matrix[kingRow, kingCol] = '-';
                            isOut = true;
                        }
                        else if (Char.IsDigit(matrix[kingRow + 1, kingCol]))
                        {
                            sum += matrix[kingRow + 1, kingCol]-48;
                            matrix[kingRow, kingCol] = '-';
                            kingRow += 1;
                            matrix[kingRow, kingCol] = 'A';
                            if (sum >= 65)
                            {
                                Console.WriteLine(PrintEnd(matrix, sum));
                                return;
                            }
                        }
                        else if (matrix[kingRow + 1, kingCol] == 'M')
                        {
                            int mirrorRow = 0;
                            int mirrorCol = 0;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (i != kingRow + 1 && j != kingCol && matrix[kingRow + 1, kingCol] == matrix[i, j])
                                    {
                                        mirrorRow = i;
                                        mirrorCol = j;
                                    }
                                }
                            }
                            matrix[kingRow, kingCol] = '-';
                            matrix[kingRow + 1, kingCol] = '-';
                                kingRow = mirrorRow;
                                kingCol = mirrorCol;
                                matrix[kingRow, kingCol] = 'A';
                            
                        }
                        break;
                    case "right":
                        if (kingCol + 1 > matrix.GetLength(1) - 1)
                        {
                            matrix[kingRow, kingCol] = '-';
                            isOut = true;
                        }
                        else if (Char.IsDigit(matrix[kingRow, kingCol+1]))
                        {
                            sum += matrix[kingRow, kingCol + 1] - 48;
                            matrix[kingRow, kingCol] = '-';
                            kingCol += 1;
                            matrix[kingRow, kingCol] = 'A';
                            if (sum >= 65)
                            {
                                Console.WriteLine(PrintEnd(matrix, sum));
                                return;
                            }
                        }
                        else if (matrix[kingRow, kingCol + 1] == 'M')
                        {
                            int mirrorRow = 0;
                            int mirrorCol = 0;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (i != kingRow && j != kingCol+1 && matrix[kingRow, kingCol + 1] == matrix[i, j])
                                    {
                                        mirrorRow = i;
                                        mirrorCol = j;
                                    }
                                }
                            }


                            matrix[kingRow, kingCol] = '-';
                            matrix[kingRow, kingCol + 1] = '-';
                            kingRow = mirrorRow;
                            kingCol = mirrorCol;
                            matrix[kingRow, kingCol] = 'A';

                        }
                        break;
                    case "left":
                        if (kingCol - 1 < 0)
                        {
                            matrix[kingRow, kingCol] = '-';
                            isOut = true;
                        }
                        else if (Char.IsDigit(matrix[kingRow, kingCol - 1]))
                        {
                            sum += matrix[kingRow, kingCol - 1]-48;
                            matrix[kingRow, kingCol] = '-';
                            kingCol -= 1;
                            matrix[kingRow, kingCol] = 'A';
                            if (sum >= 65)
                            {
                                Console.WriteLine(PrintEnd(matrix, sum));
                                return;
                            }
                        }
                        else if (matrix[kingRow, kingCol - 1] == 'M')
                        {
                            int mirrorRow = 0;
                            int mirrorCol = 0;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (i != kingRow && j != kingCol - 1 && matrix[kingRow, kingCol - 1] == matrix[i, j])
                                    {
                                        mirrorRow = i;
                                        mirrorCol = j;
                                    }
                                }
                            }

                            matrix[kingRow, kingCol] = '-';
                            matrix[kingRow, kingCol - 1] = '-';
                            kingRow = mirrorRow;
                            kingCol = mirrorCol;
                            matrix[kingRow, kingCol] = 'A';

                        }
                        break;
                }

                if (isOut)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("I do not need more swords!");
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
