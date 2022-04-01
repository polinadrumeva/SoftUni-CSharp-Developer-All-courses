using System;

namespace ME02.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[][] numbers = new int[number][];

            for (int i = 0; i < number; i++)
            {
                int[] row = new int[i + 1];
                row[0] = 1;
                row[i] = 1;

                for (int k = 0; k < i; k++)
                {
                    row[k] = numbers[i - 1][k] + numbers[i - 1][k - 1];
                }
                numbers[i] = row;
            }
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(numbers[i]));
            }
           
        }

    }
}
