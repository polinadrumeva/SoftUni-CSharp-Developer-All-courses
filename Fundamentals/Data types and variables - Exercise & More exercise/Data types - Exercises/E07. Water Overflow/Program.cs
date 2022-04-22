using System;

namespace E07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            int total = 0;

            for (int i = 0; i < n; i++)
            {
                int litres = int.Parse(Console.ReadLine());
                total += litres;
                if (total > capacity)
                {
                    total -= litres;
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(total);

        }
    }
}
