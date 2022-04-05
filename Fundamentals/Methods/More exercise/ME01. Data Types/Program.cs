using System;

namespace M05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string types = Console.ReadLine();
            PrintResult(command, types);
        }
        static void PrintResult(string command, string types)
        {
            switch (command)
            {
                case "int":
                    int result = int.Parse(types) * 2;
                    Console.WriteLine(result);
                    break;
                case "real":
                    double resultReal = double.Parse(types) * 1.5;
                    Console.WriteLine($"{resultReal:f2}");
                    break;
                case "string":
                    Console.WriteLine($"${types}$");
                    break;
            }
        }
    }
}
