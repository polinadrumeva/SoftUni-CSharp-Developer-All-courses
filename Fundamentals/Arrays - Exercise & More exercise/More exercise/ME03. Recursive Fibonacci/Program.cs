using System;

namespace ME04.RecursiveFibonacci
{
    internal class Program
    {
        public static int Fib(int num)
        {
            if (num <= 2)
            {
                return 1;
            }
            else
            {
                return Fib(num - 1) + Fib(num - 2);

            }

        }

        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Fib(num));
        }
    }

}