using System;

namespace E04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string encryptVersion = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                char newSymbol = (char)((int)text[i] + 3);
                encryptVersion += newSymbol;

            }

            Console.WriteLine(encryptVersion);
        }
    }
}
