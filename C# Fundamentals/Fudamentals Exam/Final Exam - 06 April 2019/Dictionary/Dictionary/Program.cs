using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputWordEndDescript = Console.ReadLine().Split(" | ");
            string[] words = Console.ReadLine().Split(" | ");

            var wordEndDescript = new SortedDictionary<string, List<string>>();

            foreach (var item in inputWordEndDescript)
            {
                string[] inputArray = item.Split(": ");
                if (!wordEndDescript.ContainsKey(inputArray[0]))
                {
                    wordEndDescript.Add(inputArray[0], new List<string>());
                }

                wordEndDescript[inputArray[0]].Add(inputArray[1]);
            }

            foreach (var word in words)
            {
                if (wordEndDescript.ContainsKey(word))
                {
                    Console.WriteLine($"{word}");
                    foreach (var item in wordEndDescript[word].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($" -{item}");
                    }
                }
            }

            string command = Console.ReadLine();

            if (command == "List")
            {

                Console.WriteLine(string.Join(" ", wordEndDescript.Keys));
            }

        }
    }
}
