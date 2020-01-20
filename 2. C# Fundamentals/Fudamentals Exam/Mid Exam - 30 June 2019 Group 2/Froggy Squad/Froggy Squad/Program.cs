using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> froggs = Console.ReadLine().Split().ToList();

            string[] input = Console.ReadLine().Split();

            while (true)
            {
                if (input[0] == "Join")
                {
                    if (!froggs.Contains(input[1]))
                    {
                        froggs.Add(input[1]);
                    }
                }
                else if (input[0] == "Jump")
                {
                    string nameFrogg = input[1];
                    int index = int.Parse(input[2]);

                    bool indexValidate = index >= 0 && index < froggs.Count;

                    if (indexValidate)
                    {
                        froggs.Insert(index, nameFrogg);
                    }
                }
                else if (input[0] == "Dive")
                {
                    int index = int.Parse(input[1]);

                    bool indexValidate = index >= 0 && index < froggs.Count;

                    if (indexValidate)
                    {
                        froggs.RemoveAt(index);
                    }
                }
                else if (input[0] == "First")
                {
                    int count = int.Parse(input[1]);
                    count = Math.Min(froggs.Count, count);

                    var firstFroggs = new List<string>();

                    for (int i = 0; i < count; i++)
                    {
                        firstFroggs.Add(froggs[i]);
                    }
                    Console.WriteLine(string.Join(" ", firstFroggs));
                }
                else if (input[0] == "Last")
                {
                    int count = int.Parse(input[1]);
                    count = Math.Min(froggs.Count, count);

                    var lastFroggs = new List<string>();

                    for (int i = froggs.Count - count; i < froggs.Count; i++)
                    {
                        lastFroggs.Add(froggs[i]);
                    }
                    Console.WriteLine(string.Join(" ", lastFroggs));
                }
                else if (input[1] == "Normal")
                {
                    Console.Write("Frogs: ");
                    Console.WriteLine(string.Join(" ", froggs));
                    break;
                }
                else if (input[1] == "Reversed")
                {
                    froggs.Reverse();
                    Console.Write("Frogs: ");
                    Console.WriteLine(string.Join(" ", froggs));
                    break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
