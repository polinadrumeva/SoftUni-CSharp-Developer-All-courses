using System;

namespace E10._Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int startingPower = power;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int count = 0;


            while (power >= distance)
            {
                power -= distance;
                count++;

                if (power == startingPower / 2)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(count);

        }
    }
}
