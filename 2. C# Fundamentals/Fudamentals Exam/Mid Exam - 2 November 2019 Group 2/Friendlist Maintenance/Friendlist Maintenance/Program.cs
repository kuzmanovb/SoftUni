using System;
using System.Linq;

namespace Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            var frends = Console.ReadLine().Split(", ").ToList();
            int blacklisted = 0;
            int lost = 0;


            string input = Console.ReadLine();

            while (input != "Report")
            {
                string[] inputArr = input.Split();

                string command = inputArr[0];

                if (command == "Blacklist")
                {
                    string name = inputArr[1];

                    if (frends.Contains(name))
                    {
                        int indexName = frends.IndexOf(name);

                        frends.Insert(indexName, "Blacklisted");
                        frends.RemoveAt(indexName + 1);
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (command == "Error")
                {
                    int index = int.Parse(inputArr[1]);

                    bool validIndex = index >= 0 && index < frends.Count;

                    if (validIndex)
                    {
                        string user = frends[index];

                        bool checkBlacklistEndLost = user != "Blacklisted" && user != "Lost";

                        if (checkBlacklistEndLost)
                        {
                            frends[index] = "Lost";
                            Console.WriteLine($"{user} was lost due to an error.");
                        }
                    }
                }
                else if (command == "Change")
                {
                    int index = int.Parse(inputArr[1]);
                    string name = inputArr[2];

                    bool validIndex = index >= 0 && index < frends.Count;

                    if (validIndex)
                    {
                        string curentName = frends[index];
                        frends[index] = name;

                        Console.WriteLine($"{curentName} changed his username to {name}.");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in frends)
            {
                if (item == "Blacklisted")
                {
                    blacklisted++;
                }
                else if (item == "Lost")
                {
                    lost++;
                }

            }

            Console.WriteLine($"Blacklisted names: {blacklisted}");

            Console.WriteLine($"Lost names: {lost}");

            Console.WriteLine(string.Join(" ", frends));
        }
    }
}
