using System;
using System.Collections.Generic;

namespace L06._8_Queens_Puzzle
{
    internal class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            var board = new bool[8, 8];
            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (CanPlaceQueen(row, i))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(i);
                    attackedLeftDiagonals.Add(row - i);
                    attackedRightDiagonals.Add(row + i);
                    board[row, i] = true;

                    PutQueens(board, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(i);
                    attackedLeftDiagonals.Remove(row - i);
                    attackedRightDiagonals.Remove(row + i);
                    board[row, i] = false;
                }
            }
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int i)
        {
            return !attackedRows.Contains(row) 
                && !attackedCols.Contains(i) 
                && !attackedLeftDiagonals.Contains(row -i)
                && !attackedRightDiagonals.Contains(row + i);
        }
    }
}
