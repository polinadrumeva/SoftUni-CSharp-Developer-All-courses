using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Permutations_with_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var element = Console.ReadLine().Split(' ');
            Permute(0, element);
        }

        private static void Permute(int index, string[] element)
        {
            if (index >= element.Length)
            {
                Console.WriteLine(string.Join(" ", element));
                return;
            }
            
                Permute(index + 1, element);
                var swapped = new HashSet<string> { element[index] };
            
            

            for (int i = index + 1; i < element.Length; i++)
            {
                if (!swapped.Contains(element[i]))
                {
                    Swap(index, i, element);
                    Permute(index + 1, element);
                    Swap(index, i, element);

                    swapped.Add(element[i]);
                }
            }
        }

        private static void Swap(int first, int second, string[] element)
        {
            var last = element[first];
            element[first] = element[second];
            element[second] = last; 
        }
    }
}
