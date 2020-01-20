using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int countInput = int.Parse(Console.ReadLine());

            var rg = new Regex(@"^(\$|%)([A-Z][a-z]{2,})\1:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$");

            for (int i = 0; i < countInput; i++)
            {
                string input = Console.ReadLine();
                if (rg.IsMatch(input))
                {
                    var massage = rg.Match(input);

                    string tag = massage.Groups[2].Value;
                    int charOne = int.Parse(massage.Groups[3].Value);
                    int charTwo = int.Parse(massage.Groups[4].Value);
                    int charThree = int.Parse(massage.Groups[5].Value);

                    Console.WriteLine($"{tag}: {(char)charOne}{(char)charTwo}{(char)charThree}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
