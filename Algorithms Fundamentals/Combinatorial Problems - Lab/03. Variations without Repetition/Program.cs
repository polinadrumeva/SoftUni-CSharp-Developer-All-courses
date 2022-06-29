using System;

namespace _03._Variations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] element = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            string[] newElements = new string[k];
            bool[] used = new bool[element.Length];
            Variation(0, newElements, element, used);
        }

        private static void Variation(int index, string[] newElements, string[] element, bool[] used)
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
                    Variation(index + 1, newElements, element, used);
                    used[i] = false;
                }
            }
        }
    }
}
