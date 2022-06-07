using System;
using System.Linq;

namespace AE07._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lentgh = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ");

            Func<string[], string[]> modifyNames = x => x.Where(x => x.Length <= lentgh).ToArray();
            names = modifyNames(names);
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
