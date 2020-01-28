using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_5._Directory_Traversal
{
    public class FileInformation
    {

        public FileInformation(string name, double size)
        {
            FileName = name;
            FileSize = size;
        }
        public string FileName { get; set; }
        public double FileSize { get; set; }

        public string FileInfoString()
        {
            return $"--{FileName} - {FileSize:f3}kb";
        }
    }
}
