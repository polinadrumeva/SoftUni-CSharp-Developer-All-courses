using System;
using System.Linq;

namespace AL04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => (x * 1.2));

            foreach (var item in line)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
