using System;

namespace ME01._Encrypt__Sort__and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int currentNum = 0;
            int currentSum = 0;
            int[] sums = new int[numbers];


            for (int i = 0; i < numbers; i++)
            {
                string name = Console.ReadLine();
                for (int k = 0; k < name.Length; k++)
                {
                    char symbol = name[k];
                    bool isVowel = symbol == 'a' || symbol == 'i' || symbol == 'o' || symbol == 'u' || symbol == 'e'
                        || symbol == 'A' || symbol == 'I' || symbol == 'O' || symbol == 'U' || symbol == 'E';
                    if (isVowel)
                    {
                        currentNum = (int)symbol * name.Length;
                        currentSum += currentNum;

                    }
                    else
                    {
                        currentNum = (int)symbol / name.Length;
                        currentSum += currentNum;
                    }

                    currentNum = 0;

                }
                sums[i] = currentSum;
                currentSum = 0;
            }

            Array.Sort(sums);

            Console.WriteLine(String.Join("\n", sums));
        }
    }
}
