using System;

namespace M04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 1; i <= count; i++)
            {
                Console.Write($"{PrintFib(i)} ");
            }
            Console.WriteLine();
        }


        static int PrintFib(int count)
        {
            if (count <= 2)
            {
                return 1;
            }
            if (count <= 3)
            {
                return 2;
            }
            else
            {
                return PrintFib(count - 3) + PrintFib(count - 2) + PrintFib(count - 1);
            }

        }

    }

}


