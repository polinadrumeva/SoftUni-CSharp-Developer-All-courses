using System;

namespace AL04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int square = int.Parse(Console.ReadLine());
            char[,] symbols = new char[square, square];

            for (int i = 0; i < square; i++)
            {
                string input = Console.ReadLine();
                for (int k = 0; k < square; k++)
                {
                    symbols[i, k] = input[k];
                }
            }

            char searchingSymbol = char.Parse(Console.ReadLine());
            for (int i = 0; i < square; i++)
            {
                for (int k = 0; k < square; k++)
                {
                    if (searchingSymbol == symbols[i, k])
                    {
                        Console.WriteLine($"({i}, {k})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{searchingSymbol} does not occur in the matrix");
        }
    }
}
