using System;
using System.Linq;

namespace E07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 0;
            int lastCount = 0;
            int repeatDigit = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = i+1; k < numbers.Length; k++)
                {
                    if (numbers[i] == numbers[k])
                    {
                        count++;

                        if (count > lastCount)
                        {
                            lastCount = count;
                            repeatDigit = numbers[i];

                        }
                    }
                    else
                    {
                        break;
                    }
                   
                }
                count = 0;
            }

            int[] repeatArray = new int[lastCount+1];
            for (int i = 0; i < repeatArray.Length; i++)
            {
                repeatArray[i] = repeatDigit;
            }

            Console.WriteLine(String.Join(" ", repeatArray));
        }
    }
}
