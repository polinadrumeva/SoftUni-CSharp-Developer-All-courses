using System;
using System.Text;

namespace E07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            int bombPower = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if (currentSymbol == '>')
                {
                    int powerOfBomb = (int)text[i+1] - 48;
                    result.Append(currentSymbol);
                    bombPower += powerOfBomb;
                }
                else
                {
                    if (bombPower > 0)
                    {
                        bombPower--;
                    }
                    else
                    {
                        result.Append(currentSymbol);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
