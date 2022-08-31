using System;
using System.Linq;

namespace L05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Func<int[], int[]> addNumber = x => x.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiplyNumber = x => x.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtractTNumber = x => x.Select(x => x - 1).ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = addNumber(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyNumber(numbers);
                        break;
                    case "subtract":
                        numbers = subtractTNumber(numbers);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            }

        }
    }
}
