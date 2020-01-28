using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            var wordsForChack = File.ReadAllLines(@"../../../words.txt");

            string[] textForChack = File.ReadAllText(@"../../../text.txt").Split(new char[] { ' ', '-', '?', '.', ',' });

            var result = new Dictionary<string, int>();

            foreach (var word in textForChack)
            {
                if (wordsForChack.Contains(word.ToLower()))
                {
                    if (!result.ContainsKey(word.ToLower()))
                    {
                        result.Add(word.ToLower(), 0);
                    }
                    result[word.ToLower()]++;
                }
            }

            List<string> actualResult = result.Select(x => $"{x.Key} - {x.Value}").ToList();
            List<string> expectedResult = result.OrderByDescending(x => x.Value).Select(x => $"{x.Key} - {x.Value}").ToList();


            File.WriteAllLines(@"../../../actualResult.txt", actualResult);
            File.WriteAllLines(@"../../../expectedResult.txt", expectedResult);

        }
    }
}
