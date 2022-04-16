using System;
using System.Collections.Generic;
using System.Linq;

namespace E03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fileName = Console.ReadLine().Split("\\");

            string lastName = fileName[fileName.Length - 1];

            string[] nameAndType = lastName.Split(".");
            string name = nameAndType[0];
            string extension = nameAndType[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}
