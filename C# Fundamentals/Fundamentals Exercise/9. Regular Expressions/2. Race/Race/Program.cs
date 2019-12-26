using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameRacer = new Dictionary<string, int>();

            var inputName = Console.ReadLine().Split(", ");

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = null;
                int range = 0;

                foreach (var item in input)
                {
                    if (char.IsLetter(item))
                    {
                        name += item;
                    }
                    else if (char.IsDigit(item))
                    {
                        range += item - 48;
                    }
                }

                if (inputName.Contains(name))
                {
                    if (!nameRacer.ContainsKey(name))
                    {
                        nameRacer.Add(name, 0);
                    }
                    nameRacer[name] += range;
                }

                input = Console.ReadLine();
            }

            var endRacer = nameRacer.OrderByDescending(x => x.Value).Select(x => x.Key).ToArray();

            Console.WriteLine($"1st place: {endRacer[0]}");
            Console.WriteLine($"2nd place: {endRacer[1]}");
            Console.WriteLine($"3rd place: {endRacer[2]}");

        }
    }
}
