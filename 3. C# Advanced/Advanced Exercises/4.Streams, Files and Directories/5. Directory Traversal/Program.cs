using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Problem_5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(Console.ReadLine());

            var allFilesInDirectory = directory.GetFiles();

            var report = new Dictionary<string, List<FileInformation>>();
            FillReport(allFilesInDirectory, report);


            var SortedReportForAddToExportFile = new List<string>();
            SortReport(report, SortedReportForAddToExportFile);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllLines(path + "\\report.txt", SortedReportForAddToExportFile);
        }

        private static void SortReport(Dictionary<string, List<FileInformation>> report, List<string> sortedListReport)
        {
            foreach (var (key, value) in report.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                sortedListReport.Add(key);
                foreach (var item in value.OrderBy(x => x.FileSize))
                {
                    sortedListReport.Add(item.FileInfoString());
                }
            }
        }

        private static void FillReport(FileInfo[] allFiles, Dictionary<string, List<FileInformation>> report)
        {
            foreach (var file in allFiles)
            {
                var curentExtension = file.Extension;
                var curentName = file.Name;
                double curentSize = file.Length * 1.0 / 1024;
                if (!report.ContainsKey(curentExtension))
                {
                    report.Add(curentExtension, new List<FileInformation>());
                }

                report[curentExtension].Add(new FileInformation(curentName, curentSize));
            }
        }
    }
}
