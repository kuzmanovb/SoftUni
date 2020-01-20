using System;
using System.Linq;
using System.Collections.Generic;

namespace On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {

            var stores = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArr = input.Split("->");

                if (inputArr[0] == "Add")
                {
                    string[] itemForAdd = inputArr[2].Split(",");

                    if (!stores.ContainsKey(inputArr[1]))
                    {
                        stores.Add(inputArr[1], new List<string>());
                    }
                    foreach (var item in itemForAdd)
                    {
                        stores[inputArr[1]].Add(item);
                    }
                }
                else if (inputArr[0] == "Remove")
                {
                    if (stores.ContainsKey(inputArr[1]))
                    {
                        stores.Remove(inputArr[1]);
                    }
                }

                input = Console.ReadLine();
            }

            stores = stores.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key).ToDictionary(x=>x.Key, x=>x.Value);

            Console.WriteLine("Stores list:");
            foreach (var store in stores)
            {
                Console.WriteLine(store.Key);
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }

        }
    }
}
