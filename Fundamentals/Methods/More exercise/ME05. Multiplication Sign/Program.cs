using System;

namespace M05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            PrintResult(first, second, third);
        }
        static void PrintResult(int first, int second, int third)
        {
            if (first == 0 || second == 0 || third == 0)
            {
                Console.WriteLine("zero");
            }
            else if (first < 0 || second < 0 || third < 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
