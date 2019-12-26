using System;

namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\');

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains('.'))
                {
                    string[] filePrint = input[i].Split('.');
                    
                    Console.WriteLine($"File name: {filePrint[0]}");
                    Console.WriteLine($"File extension: {filePrint[1]}");
                    break;
                }
            }
        }
    }
}
