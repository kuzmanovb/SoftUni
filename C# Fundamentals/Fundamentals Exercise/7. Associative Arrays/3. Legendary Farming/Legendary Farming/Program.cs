using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {

            var legendaryFarming = new Dictionary<string, int>()
            {
                {"shards", 0 },
                {"fragments", 0},
                {"motes", 0 }
            };

            bool finish = false;
            while (!finish)
            {

                string[] input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length; i += 2)
                {
                    int valueItem = int.Parse(input[i]);
                    string nameItem = input[i + 1].ToLower(); ;

                    if (legendaryFarming.ContainsKey(nameItem))
                    {
                        legendaryFarming[nameItem] += valueItem;
                    }
                    else
                    {
                        legendaryFarming.Add(nameItem, valueItem);
                    }

                    bool validName = nameItem == "shards" || nameItem == "fragments" || nameItem == "motes";
                    if (legendaryFarming[nameItem] >= 250 && validName)
                    {
                        finish = true;
                        switch (nameItem)
                        {
                            case "shards": Console.WriteLine("Shadowmourne obtained!"); break;
                            case "fragments": Console.WriteLine("Valanyr obtained!"); break;
                            case "motes": Console.WriteLine("Dragonwrath obtained!"); break;
                        }
                        legendaryFarming[nameItem] -= 250;
                        break;
                    }
                }
            }


            var material = legendaryFarming.Where(x => x.Key == "shards" || x.Key == "fragments" || x.Key == "motes").ToDictionary(x => x.Key, x => x.Value);
            var junk = legendaryFarming.Where(x => x.Key != "shards" && x.Key != "fragments" && x.Key != "motes").OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            material = material.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in material)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            foreach (var item in junk)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
