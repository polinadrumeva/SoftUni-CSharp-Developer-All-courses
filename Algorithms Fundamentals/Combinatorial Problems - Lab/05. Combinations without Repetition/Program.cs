using System;

namespace _05._Combinations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] element = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            string[] newElements = new string[k];
            Combination(0,0, newElements, element);
        }

        private static void Combination(int index, int startIndex, string[] newElements, string[] element)
        {
            if (index >= newElements.Length)
            {
                Console.WriteLine(string.Join(" ", newElements));
                return;
            }

            for (int i = startIndex; i < element.Length; i++)
            {

                newElements[index] = element[i];
                Combination(index + 1,i + 1, newElements, element);

            }
        }
    }
}
