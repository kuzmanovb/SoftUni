using System;
using System.Text.RegularExpressions;

namespace The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {

            var matchPatern = new Regex(@"^(#|\$|%|\*|&)(\w+)\1=(\d+)!{2}(.+)$");

            bool end = true;

            while (end)
            {
                string input = Console.ReadLine();

                if (matchPatern.IsMatch(input))
                {
                    var racer = matchPatern.Match(input);

                    string name = racer.Groups[2].Value;
                    string geocode = racer.Groups[4].Value;
                    int lengthCode = int.Parse(racer.Groups[3].Value);

                    if (geocode.Length != lengthCode)
                    {
                        Console.WriteLine("Nothing found!");
                    }
                    else
                    {
                        string code = null;

                        foreach (var item in geocode)
                        {
                            code += (char)(item + lengthCode);
                        }
                        
                        Console.WriteLine($"Coordinates found! {name} -> {code}");
                        end = false;
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
