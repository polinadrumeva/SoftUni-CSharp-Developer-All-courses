using System;

namespace E04.Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] all = Console.ReadLine().Split(" ");
            int sum = 0;

            foreach (var item in all)
            {
                try
                {
                    int number = int.Parse(item);
                    sum += number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
