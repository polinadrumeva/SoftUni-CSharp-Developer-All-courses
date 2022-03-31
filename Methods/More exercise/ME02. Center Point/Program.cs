using System;

namespace M02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintNearestPoint(x1, y1, x2, y2);
        }

        static void PrintNearestPoint(double x1, double y1, double x2, double y2)
        {
            double diffx1y1 = Math.Abs(x1) + Math.Abs(y1);
            double diffx2y2 = Math.Abs(x2) + Math.Abs(y2);

            if (diffx1y1 < diffx2y2 || diffx1y1 == diffx2y2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (diffx1y1 > diffx2y2)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
