using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split('|').ToList();

            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                string[] inputArray = input.Split();

                if (inputArray[0] == "Loot")
                {
                    for (int i = 1; i < inputArray.Length; i++)
                    {
                        if (!treasure.Contains(inputArray[i]))
                        {
                            treasure.Insert(0, inputArray[i]);
                        }
                    }
                }
                else if (inputArray[0] == "Drop")
                {
                    int index = int.Parse(inputArray[1]);

                    if (index >= 0 && index < treasure.Count)
                    {
                        string item = treasure[index];
                        treasure.RemoveAt(index);
                        treasure.Add(item);
                    }
                }
                else if (inputArray[0] == "Steal")
                {
                    int itemRemove = int.Parse(inputArray[1]);
                    int indexStar = treasure.Count - itemRemove;
                    bool check = false;

                    if (indexStar < 0)
                    {
                        indexStar = 0;
                        check = true;
                    }

                    List<string> removeItem = new List<string>();

                    for (int i = indexStar; i < treasure.Count; i++)
                    {
                        removeItem.Add(treasure[i]);
                    }

                    Console.WriteLine(string.Join(", ", removeItem));

                    if (check)
                    {
                        treasure = new List<string>();
                    }
                    else
                    {
                        treasure.RemoveRange(indexStar, itemRemove);
                    }
                }
                input = Console.ReadLine();
            }

            if (treasure.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }

            else
            {

                decimal count = 0;
                foreach (var item in treasure)
                {
                    count += item.Length;
                }

                count = (count * 1.0m) / treasure.Count;

                Console.WriteLine($"Average treasure gain: {count:f2} pirate credits.");
            }

        }
    }
}
