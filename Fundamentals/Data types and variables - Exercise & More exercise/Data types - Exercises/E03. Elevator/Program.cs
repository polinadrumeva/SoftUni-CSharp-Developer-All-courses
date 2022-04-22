using System;

namespace E03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeole = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double courses = (double)numberOfPeole / capacity;
            Console.WriteLine(Math.Ceiling(courses));
        }
    }
}
