using System;

namespace Ex02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];
            int whitePawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;

            for (int rows = 0; rows < 8; rows++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < 8; cols++)
                {
                    matrix[rows, cols] = data[cols];
                    if (matrix[rows, cols] == 'w')
                    {
                        whitePawnRow = rows;
                        whitePawnCol = cols;
                    }
                    else if (matrix[rows, cols] == 'b')
                    {
                        blackPawnRow = rows;
                        blackPawnCol = cols;
                    }
                }
            }
            char col = ' ';
            string row = string.Empty;
            string coordinate = string.Empty;

            while (true)
            {
                if (whitePawnRow - 1 < 0)
                {
                    col = (char)(97 + whitePawnCol);
                    row = (8 - whitePawnRow).ToString();
                    coordinate = col + row;
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinate}.");
                    return;
                }
                else if (whitePawnCol + 1 <= matrix.GetLength(1) - 1 || whitePawnCol - 1 >= 0)
                {
                    if (matrix[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                    {
                        col = (char)(97 + (whitePawnCol + 1));
                        row = (8 - whitePawnRow + 1).ToString();
                        coordinate = col + row;

                        Console.WriteLine($"Game over! White capture on {coordinate}.");
                        break;
                    }
                    else if (matrix[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                    {
                         col = (char)(97 + (whitePawnCol - 1));
                         row = (8 - whitePawnRow + 1).ToString();
                         coordinate = col + row;

                        Console.WriteLine($"Game over! White capture on {coordinate}.");
                        break;
                    }
                }
                
                    matrix[whitePawnRow, whitePawnCol] = '-';
                    whitePawnRow--;
                    matrix[whitePawnRow, whitePawnCol] = 'w';
                

                if (blackPawnRow + 1 > matrix.GetLength(0) - 1)
                {
                    col = (char)(97 + blackPawnCol);
                    row = (8 - blackPawnRow).ToString();
                    coordinate = col + row;
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinate}.");
                    return;
                }
                else if (blackPawnCol + 1 <= matrix.GetLength(1)-1 || blackPawnCol - 1 >= 0)
                {
                    if (matrix[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                    {
                        col = (char)(97 + (blackPawnCol + 1));
                        row = (8 - blackPawnRow - 1).ToString();
                        coordinate = col + row;

                        Console.WriteLine($"Game over! Black capture on {coordinate}.");
                        break;
                    }
                    else if (matrix[blackPawnRow + 1, blackPawnCol - 1] == 'w')
                    {
                        col = (char)(97 + (blackPawnCol - 1));
                        row = (8 - blackPawnRow - 1).ToString();
                        coordinate = col + row;

                        Console.WriteLine($"Game over! Black capture on {coordinate}.");
                        break;
                    }
                }
                
                    matrix[blackPawnRow, blackPawnCol] = '-';
                    blackPawnRow++;
                    matrix[blackPawnRow, blackPawnCol] = 'b';
                
            }

        }
    }
}
