using System;
using System.Text.RegularExpressions;

namespace Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            var rg = new Regex(@"^([A-Za-z\d!@#$\?]+)=(\d+)<{2}(.*)");

            string input = Console.ReadLine();

            while (input != "Last note")
            {

                if (rg.IsMatch(input))
                {
                    var inputMatch = rg.Match(input);

                    var lenghtGeo = int.Parse(inputMatch.Groups[2].Value);
                    var geo = inputMatch.Groups[3].Value;

                    if (geo.Length != lenghtGeo)
                    {
                        Console.WriteLine("Nothing found!");
                    }
                    else
                    {
                        string name = null;

                        foreach (var item in inputMatch.Groups[1].Value)
                        {
                            if (char.IsLetter(item))
                            {
                                name += item;
                            }
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {inputMatch.Groups[3].Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

                input = Console.ReadLine();
            }

        }
    }
}
