using System;

namespace E08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string biggerKeg = String.Empty;
            double volume = 0;
            double biggerVolume = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                volume = Math.PI * (radius * radius) * height;

                if (volume > biggerVolume)
                {
                    biggerVolume = volume;
                    biggerKeg = model;
                }
                volume = 0;
            }
            Console.WriteLine(biggerKeg);

        }
    }
}
