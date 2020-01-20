using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var concertBand = new Dictionary<string, Band>();

            string input = Console.ReadLine();
            int totalTime = 0;

            while (input != "start of concert")
            {
                string[] inputArr = input.Split("; ");
                string command = inputArr[0];
                string nameBand = inputArr[1];

                if (!concertBand.ContainsKey(nameBand))
                {
                    concertBand.Add(nameBand, new Band());
                    concertBand[nameBand].Member = new List<string>();

                }

                if (command == "Add")
                {
                    string[] membersForAdd = inputArr[2].Split(", ");

                    foreach (var item in membersForAdd)
                    {
                        if (!concertBand[nameBand].Member.Contains(item))
                        {
                            concertBand[nameBand].Member.Add(item);
                        }
                    }
                }
                else if (command == "Play")
                {
                    concertBand[nameBand].Time += int.Parse(inputArr[2]);
                    totalTime += int.Parse(inputArr[2]);
                }

                input = Console.ReadLine();
            }

            string bandPrint = Console.ReadLine();

            concertBand = concertBand.OrderByDescending(x => x.Value.Time).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var item in concertBand)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Time}");
            }
            Console.WriteLine(bandPrint);
            foreach (var item in concertBand)
            {
                if (item.Key == bandPrint)
                {
                    foreach (var member in item.Value.Member)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }

        }
    }
    public class Band
    {
        public Band()
        {
            var Member = new List<string>();
        }

        public int Time { get; set; }

        public List<string> Member { get; set; }
    }
}
