using System;
using System.Linq;

namespace AE02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(" ");

            Action<string> sirLine = word => Console.WriteLine($"Sir {word}");

            for (int word = 0; word < line.Length; word++)
            {
                sirLine(line[word]);
            }

        }
    }
}
