using System;

namespace E04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int mathSymbol = (int)symbol;
                sum += mathSymbol;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
