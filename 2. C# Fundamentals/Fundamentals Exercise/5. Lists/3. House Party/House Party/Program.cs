using System;
using System.Collections.Generic;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> party = new List<string>();

            int numberCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommand; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                string command = input[2];

                if (command == "going!")
                {
                    if (party.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        party.Add(name);
                    }
                }
                else if (input[2] == "not")
                {
                    if (party.Contains(name))
                    {
                        party.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var item in party)
            {
                Console.WriteLine(item);
            }
        }
    }
}
