using System;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            double highest = double.MinValue;
            int lastSnowballSnow = 0;
            int lastSnowballTime = 0;
            int lastSnowballQuality = 0;


            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int firstValue = snowballSnow / snowballTime;
                double snowValue = Math.Pow(firstValue, snowballQuality);
                if (snowValue > highest)
                {
                    lastSnowballSnow = snowballSnow;
                    lastSnowballTime = snowballTime;
                    lastSnowballQuality = snowballQuality;
                    highest = snowValue;
                }

            }
            Console.WriteLine($"{lastSnowballSnow} : {lastSnowballTime} = {highest} ({lastSnowballQuality})");
        }
    }
}
