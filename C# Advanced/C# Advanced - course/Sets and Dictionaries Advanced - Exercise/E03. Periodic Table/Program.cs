using System;
using System.Collections.Generic;
using System.Linq;

namespace E03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SortedSet<string> periodTable = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] elements = Console.ReadLine().Split(' ');
                for (int j = 0; j < elements.Length; j++)
                {
                    if (!periodTable.Contains(elements[j]))
                    {
                        periodTable.Add(elements[j]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", periodTable));
        }
    }
}
