using System;

namespace _04._Variations_with_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] element = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            string[] newElements = new string[k];
            Variation(0, newElements, element);
        }

        private static void Variation(int index, string[] newElements, string[] element)
        {
            if (index >= newElements.Length)
            {
                Console.WriteLine(string.Join(" ", newElements));
                return;
            }

            for (int i = 0; i < element.Length; i++)
            {
                
                    newElements[index] = element[i];
                    Variation(index + 1, newElements, element);
                
            }
        }
    }
}
