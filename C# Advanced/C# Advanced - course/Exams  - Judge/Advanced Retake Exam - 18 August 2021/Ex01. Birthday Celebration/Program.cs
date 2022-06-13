using System;

namespace Ex01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceGuests = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] sequencePlate = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        }
    }
}
