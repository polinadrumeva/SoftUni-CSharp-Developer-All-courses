namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> mofifiedText = new List<string>();

            foreach (string line in lines)
            {
                count++;

                int countLetter = line.Count(char.IsLetter);
                int countPunct = line.Count(char.IsPunctuation);
                string modified = $"Line {count}: {line} ({countLetter})({countPunct})";
                mofifiedText.Add(modified);
            }

            File.AppendAllLines(outputFilePath, mofifiedText);
        }
    }
}
