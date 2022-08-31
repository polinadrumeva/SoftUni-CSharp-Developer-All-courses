using System;

namespace E01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                if (a < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(a));
                }
               
            }
           
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
