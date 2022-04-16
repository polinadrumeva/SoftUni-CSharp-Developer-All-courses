using System;
using System.Collections.Generic;
using System.Text;

namespace E06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder resultText = new StringBuilder();
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (count < 1)
                {
                    resultText.Append(text[i]);
                }
                count++;

                if (text[i] != resultText[resultText.Length -1])
                {
                    resultText.Append(text[i]);
                }

            }

            Console.WriteLine(resultText.ToString());
        }
    }
}
