using System;

namespace ME05._Decrypting_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());
            string word = String.Empty;
            for (int i = 0; i < numberOfLines; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int numSymbol = (int)symbol + key;
                char deversedSymbol = (char)numSymbol;
                word += deversedSymbol;

            }

            Console.WriteLine(word);

        }
    }
}
