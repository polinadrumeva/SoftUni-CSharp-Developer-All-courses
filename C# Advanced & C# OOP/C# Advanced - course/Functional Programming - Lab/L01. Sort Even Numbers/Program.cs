using System;
using System.Linq;

namespace L01.Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", line));
        }
    }
}
