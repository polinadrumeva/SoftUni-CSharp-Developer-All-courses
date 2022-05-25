using System;
using System.Collections.Generic;

namespace E01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
