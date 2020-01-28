using System;
using System.Collections.Generic;
using System.IO;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStream = File.ReadAllLines(@"../../../text.txt");

            var outputStream = new List<string>();

            var count = 1;
            foreach (var line in inputStream)
            {
                var letterInItem = 0;
                var punctuationInItem = 0;

                foreach (var charSymbol in line)
                {
                    if (char.IsLetter(charSymbol))
                    {
                        letterInItem++;
                    }
                    if (char.IsPunctuation(charSymbol))
                    {
                        punctuationInItem++;
                    }
                }
                
                outputStream.Add($"Line {count}: {line} ({letterInItem})({punctuationInItem})");
                count++;
            }


            File.WriteAllLines("../../../output.txt", outputStream);

        }
    }
}
