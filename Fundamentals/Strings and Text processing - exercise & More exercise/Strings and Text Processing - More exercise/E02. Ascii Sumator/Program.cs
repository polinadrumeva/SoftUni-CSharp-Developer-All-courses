using System;

namespace E02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine()); 
            string text = Console.ReadLine();

            int result = 0;

            for (int i = (int)first + 1; i < second; i++)
            {
                for (int k = 0; k < text.Length; k++)
                {
                    if ((char)i == text[k])
                    {
                        result += (int)i;
                    }
                }
                
            }
            Console.WriteLine(result);
        }
    }
}
