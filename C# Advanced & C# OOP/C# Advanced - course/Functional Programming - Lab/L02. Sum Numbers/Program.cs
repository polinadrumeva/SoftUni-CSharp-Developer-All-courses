using System;
using System.Linq;

namespace L02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse);
            Console.WriteLine(line.Count());
            Console.WriteLine(line.Sum());
        }
    }
}
