using System;
using System.Linq;

namespace AL01._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elementsNum = Console.ReadLine().Split(", ");
            int rows = int.Parse(elementsNum[0]);
            int cols = int.Parse(elementsNum[1]);
            int sum = 0;

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int k = 0; k < cols; k++)
                {
                    matrix[i, k] = numbers[k];
                    sum += numbers[k];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
