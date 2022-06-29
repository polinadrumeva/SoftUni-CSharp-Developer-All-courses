using System;
using System.Linq;

namespace _01._Permutations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] element = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();     
            char[] newElements = new char[element.Length];
            bool[] used = new bool[element.Length];
            Permute(0, newElements, element, used);
        }

        private static void Permute(int index, char[] newElements, char[] element, bool[] used)
        {
            if (index >= newElements.Length)
            {
                Console.WriteLine(string.Join(" ", newElements));
                return;
            }

            for (int i = 0; i < element.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    newElements[index] = element[i];
                    Permute(index + 1, newElements, element, used);
                    used[i] = false;
                }
            }
        }
    }
}
