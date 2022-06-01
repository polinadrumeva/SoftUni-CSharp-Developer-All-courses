using System;
using System.Collections.Generic;
using System.Linq;

namespace E11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ").ToList();

            Console.WriteLine(names.First(name => name.Select(symbol => (int)symbol).Sum() >=n));
        }
    }
}
