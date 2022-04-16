using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.__Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split(", ").ToList();

            for (int i = 0; i < text.Count; i++)
            {

                if ((text[i].Length < 3 || text[i].Length > 16))
                {
                    text[i] = "";

                }
                else
                {
                    for (int k = 0; k < text[i].Length; k++)
                    {
                        char symbol = text[i][k];
                        if (!char.IsLetterOrDigit(symbol) && symbol != '-' && symbol != '_')
                        {
                            text[i] = "";
                            break;
                        }

                    }

                }

            }

            for (int i = 0; i < text.Count; i++)
            {
                if (text[i] == "")
                {
                    text.Remove(text[i]);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, text));
        }
    }
}
