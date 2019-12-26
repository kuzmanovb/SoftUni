using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var attacked = new List<string>();
            var destroyed = new List<string>();


            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                int countLetters = 0;

                foreach (var ch in input.ToLower())
                {
                    bool charMatch = ch == 's' || ch == 't' || ch == 'a' || ch == 'r';
                    if (charMatch)
                    {
                        countLetters++;
                    }
                }
                string inputDecrypt = null;

                for (int y = 0; y < input.Length; y++)
                {
                    inputDecrypt += (char)(input[y] - countLetters);
                }

                var rg = new Regex(@"@([A-Za-z]+)[^@\-!:>]*:(\d+)[^@\-!:>]*!([AD])![^@\-!:>]*->(\d*)");

                if (rg.IsMatch(inputDecrypt))
                {
                    var inputMatch = rg.Match(inputDecrypt);
                    if (inputMatch.Groups[3].Value == "A")
                    {
                        attacked.Add(inputMatch.Groups[1].Value);
                    }
                    else if (inputMatch.Groups[3].Value == "D")
                    {
                        destroyed.Add(inputMatch.Groups[1].Value);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var item in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var item in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
