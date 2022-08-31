namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            StringBuilder sb = new StringBuilder();
            Dictionary<string, List<FileInfo>> extensionInfos = new Dictionary<string, List<FileInfo>>();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!extensionInfos.ContainsKey(extension))
                { 
                    extensionInfos.Add(extension, new List<FileInfo>());
                }
                extensionInfos[extension].Add(fileInfo);
            }

            
            foreach (var item in extensionInfos.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                string currentExtension = item.Key;
                sb.AppendLine(currentExtension);
                List<FileInfo> currentList = new List<FileInfo>();
                currentList.OrderByDescending(x => x.Length);
                foreach (var file in currentList)
                {
                    string line = $"--{file.Name} - {(file.Length/1024):F3}kb";
                    sb.AppendLine(line);
                }

            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(pathDesktop, textContent);
        }
    }
}
