namespace _03.TakeSkipRope
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            StringBuilder result = new StringBuilder();
            List<string> nonNumbers = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    numbers.Add(int.Parse(word[i].ToString()));
                }
                else
                {
                    nonNumbers.Add(word[i].ToString());
                }

            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int indexForSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumbers);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                result.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }
    }
}