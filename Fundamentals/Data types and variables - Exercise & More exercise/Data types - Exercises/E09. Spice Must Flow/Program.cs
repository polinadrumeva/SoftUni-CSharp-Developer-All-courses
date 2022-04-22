using System;

namespace E09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int startingYield = int.Parse(Console.ReadLine());
            const int MINING_CREW = 26;
            int days = 0;
            int totalAmount = 0;

            while (startingYield >= 100)
            {
                totalAmount += startingYield - MINING_CREW;
                startingYield -= 10;
                days++;
            }
            totalAmount -= MINING_CREW;
            if (totalAmount < MINING_CREW)
            {
                totalAmount += MINING_CREW;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalAmount);

        }
    }
}
