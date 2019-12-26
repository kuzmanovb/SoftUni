using System;
using System.Collections.Generic;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> countChar = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var item in input)
            {
                if (countChar.ContainsKey(item))
                {

                    countChar[item]++;
                }
                else
                {
                    if (item != ' ')
                    {
                        countChar.Add(item, 1);
                    }
                }
            }


            foreach (var item in countChar)
            {
                Console.WriteLine(item.Key + " -> "+ item.Value);
            }

        }
    }
}
