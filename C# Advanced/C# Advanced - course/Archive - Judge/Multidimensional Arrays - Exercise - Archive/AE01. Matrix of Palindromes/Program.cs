using System;
using System.Linq;

namespace AE01._Matrix_of_Palindromes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int row = num[0];
            int col = num[1];
            string[,] matrix = new string[row, col];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    string word = alphabet[i].ToString() + alphabet[i+j].ToString() + alphabet[i].ToString();
                    matrix[i, j] = word;
                }
            
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
