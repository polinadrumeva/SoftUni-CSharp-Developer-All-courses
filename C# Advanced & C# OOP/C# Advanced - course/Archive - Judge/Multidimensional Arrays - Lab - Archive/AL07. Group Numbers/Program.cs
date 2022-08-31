using System;
using System.Linq;

namespace AL07._Group_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[][] dividedNumbers = new int[3][];
            int k = 0;
            int m = 0;
            int n = 0;
            dividedNumbers[0] = new int[50];
            dividedNumbers[1] = new int[50];
            dividedNumbers[2] = new int[50];


            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] % 3 == 0)
                {
                    dividedNumbers[0][k] = numbers[i];
                    k++;
                }
                else if (numbers[i] % 3 == 1 || numbers[i] % 3 == -1)
                {
                    dividedNumbers[1][m] = numbers[i];
                    m++;
                }
                else if (numbers[i] % 3 == 2 || numbers[i] % 3 == -2)
                {
                    dividedNumbers[2][n] = numbers[i];
                    n++;
                }
            }

            dividedNumbers[0] = dividedNumbers[0].Where(x => x != 0).ToArray();
            dividedNumbers[1] = dividedNumbers[1].Where(x => x != 0).ToArray();
            dividedNumbers[2] = dividedNumbers[2].Where(x => x != 0).ToArray();

            Console.WriteLine(String.Join(" ", dividedNumbers[0]));
            Console.WriteLine(String.Join(" ", dividedNumbers[1]));
            Console.WriteLine(String.Join(" ", dividedNumbers[2]));
        }
    }
}
