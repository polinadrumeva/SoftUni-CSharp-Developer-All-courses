using System;

namespace ME03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            decimal numberA = (decimal)a;
            decimal numberB = (decimal)b;
            decimal diff = numberA - numberB;

            if (Math.Abs(diff) < 0.000001m)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

        }
    }
}