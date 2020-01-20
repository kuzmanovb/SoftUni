using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_sessions
{
    class Program
    {
        static void Main(string[] args)
        {

            var practice = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArr = input.Split("->");
                string command = inputArr[0];

                if (command == "Add")
                {
                    if (!practice.ContainsKey(inputArr[1]))
                    {
                        practice.Add(inputArr[1], new List<string>());
                    }

                    practice[inputArr[1]].Add(inputArr[2]);
                }
                else if (command == "Move")
                {
                    if (practice[inputArr[1]].Contains(inputArr[2]))
                    {
                        practice[inputArr[1]].Remove(inputArr[2]);
                        practice[inputArr[3]].Add(inputArr[2]);
                    }
                }
                else if (command == "Close")
                {
                    if (practice.ContainsKey(inputArr[1]))
                    {
                        practice.Remove(inputArr[1]);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");
            foreach (var item in practice.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var racer in item.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
