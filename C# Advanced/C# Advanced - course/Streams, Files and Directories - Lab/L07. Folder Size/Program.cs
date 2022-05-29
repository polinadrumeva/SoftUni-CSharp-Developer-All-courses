using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"../../../TestFolder";
            string outputPath = @"../../../output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo directory = new DirectoryInfo("TestFolder");
            FileInfo[] datas = directory.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo data in datas)
            { 
                sum += data.Length;
            }

            sum = sum / 1024 * 1024;
            GetFolderSize("output.txt", sum.ToString());
        }
    }
}

