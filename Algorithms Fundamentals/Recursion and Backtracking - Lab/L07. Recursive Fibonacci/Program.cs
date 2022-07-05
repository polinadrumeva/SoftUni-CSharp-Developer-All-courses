using System;

namespace L07._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateFibonachi(n));
        }

        private static int CalculateFibonachi(int n)
        {
           
            
                if (n <= 1)
                {
                    return 1;
                }
                else
                {
                    return CalculateFibonachi(n - 1) + CalculateFibonachi(n - 2);
                }
            

            
        }
    }
}
