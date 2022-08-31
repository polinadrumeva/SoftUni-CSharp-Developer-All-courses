using System;
using System.IO;

namespace L01._Odd_Lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using StreamReader text = new StreamReader("input.txt");
            using StreamWriter output = new StreamWriter("output.txt");
            int count = 0;

            while (!text.EndOfStream)
            {
                var line = text.ReadLine();
                if (count % 2 != 0)
                { 
                    output.WriteLine(line);
                }

                count++;
            }

        }
    }
}
