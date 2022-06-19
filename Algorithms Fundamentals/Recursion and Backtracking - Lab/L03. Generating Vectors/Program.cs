using System;

namespace L03._Generating_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            GetVector(vector, 0);
        }

        private static void GetVector(int[] vector, int index)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                vector[index] = i;
                GetVector(vector, index + 1);
            }
        }
    }
}
