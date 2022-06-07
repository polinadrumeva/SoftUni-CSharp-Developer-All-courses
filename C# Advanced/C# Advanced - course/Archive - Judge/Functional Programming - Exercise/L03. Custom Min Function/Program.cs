using System;
using System.Linq;

namespace AE03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int> minNumber = x => x.Min();
            Console.WriteLine(minNumber(numbers));
        }
    }
}
