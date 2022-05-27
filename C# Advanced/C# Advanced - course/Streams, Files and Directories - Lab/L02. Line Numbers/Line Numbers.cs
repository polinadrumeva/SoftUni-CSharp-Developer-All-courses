
namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                StreamWriter writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    string line;
                    int count = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{count}. {line}");
                        count++;
                    }
                }
            }
        }
    }

}



