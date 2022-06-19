using System;

namespace L04._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateFactorial(n));
        }

        private static int CalculateFactorial(int n)
        {
            if (n == 0)
            { 
                return 1;
            }

            return n * CalculateFactorial(n-1);
        }
    }
}
