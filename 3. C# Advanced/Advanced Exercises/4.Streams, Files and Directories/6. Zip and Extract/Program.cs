using System;
using System.IO.Compression;

namespace Problem_6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {

            ZipFile.CreateFromDirectory("../../../For Copy", "../../../copy.zip");

            var ExtractToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ZipFile.ExtractToDirectory("../../../copy.zip", ExtractToDesktop);
        }
    }
}
