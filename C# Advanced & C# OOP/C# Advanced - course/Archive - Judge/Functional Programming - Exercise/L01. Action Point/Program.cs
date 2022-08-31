using System;

namespace AE01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(" ");

            Action<string> outputLine = p => Console.WriteLine(p);

            foreach (var p in line)
            {
                Console.WriteLine(p);
            }
        }
    }
}
