using System;
using System.Collections.Generic;

namespace E02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] texts = Console.ReadLine().Split();
            string moreLeters = string.Empty;
            int result = 0;

            for (int i = 0; i < texts[0].Length; i++)
            {
                int currentSum = (int)texts[0][i] * (int)texts[1][i];
                result += currentSum;
            }

            if (texts[0].Length > texts[1].Length)
            {
                int diffOne = texts[0].Length - texts[1].Length;
                moreLeters = texts[0].Substring(texts[1].Length, diffOne);
            }
            else if (texts[0].Length < texts[1].Length)
            {
                int diffSecond = texts[1].Length - texts[0].Length;
                moreLeters = texts[1].Substring(texts[0].Length, diffSecond);
            }

             for (int m = 0; m < moreLeters.Length; m++)
                {
                    result += (int)moreLeters[m];
                }
            

            Console.WriteLine(result);
        }
    }
}
