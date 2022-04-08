using System;

namespace AL08._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            long[][] pascalNumbers = new long[number][];

            for (int j = 0; j < number; j++)
            {
                pascalNumbers[j] = new long[j + 1];
                pascalNumbers[j][0] = 1;
                pascalNumbers[j][pascalNumbers[j].Length - 1] = 1;

                for (int k = 1; k < pascalNumbers[j].Length - 1; k++)
                {
                    pascalNumbers[j][k] = pascalNumbers[j - 1][k - 1] + pascalNumbers[j - 1][k];

                }
            }


            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(string.Join(" ", pascalNumbers[i]));
            }
        }
    }
}
