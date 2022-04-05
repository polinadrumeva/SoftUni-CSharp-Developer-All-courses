using System;
using System.Linq;

namespace E02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split().ToArray();
            string[] secondArray = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int k = 0; k < secondArray.Length; k++)
                {
                    if (secondArray[k] == firstArray[i])
                    {
                        Console.Write($"{secondArray[k]} ");
                    }
                }
            }
        }
    }
}
