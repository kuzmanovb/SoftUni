using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInput; i++)
            {
                string input = Console.ReadLine();

                var regex = new Regex(@"(\*|@)([A-Z][a-z]{2,})\1:\s\[(\w{1})\]\|\[(\w{1})\]\|\[(\w{1})\]\|$");
                var match = regex.Match(input);

                if (match.Success)
                {
                    var name = match.Groups[2].Value;
                    int one = char.Parse(match.Groups[3].Value);
                    int two = char.Parse(match.Groups[4].Value);
                    int three = char.Parse(match.Groups[5].Value);
                    Console.WriteLine($"{name}: {one} {two} {three}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }

        }
    }
}
