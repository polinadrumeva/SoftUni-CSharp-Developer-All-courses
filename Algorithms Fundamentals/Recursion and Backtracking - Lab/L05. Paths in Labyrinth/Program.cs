using System;
using System.Collections.Generic;

namespace L05._Paths_in_Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var  lab = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            { 
                var data = Console.ReadLine();
                for (int j = 0; j < data.Length; j++)
                {
                    lab[i, j] = data[j];
                }
            }

            FindPath(lab, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPath(char[,] lab, int row, int col, List<string> directions, string direction)
        {

            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
            {
                return;
            }

            if (lab[row, col] == '*' || lab[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, col] = 'v';
            
            FindPath(lab, row - 1, col, directions, "U");
            FindPath(lab, row + 1, col, directions, "D");
            FindPath(lab, row, col - 1, directions, "L");
            FindPath(lab, row, col + 1, directions, "R");

            lab[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
