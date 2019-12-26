using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArr = input.Split(" : ");

                if (courses.ContainsKey(inputArr[0]))
                {
                    courses[inputArr[0]].Add(inputArr[1]);
                }
                else
                {
                    courses.Add(inputArr[0], new List<string> {inputArr[1] });
                }

                input = Console.ReadLine();
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x=>x.Key, x=>x.Value);
            
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                
                item.Value.Sort();
                
                foreach (var itemList in item.Value)
                {
                    Console.WriteLine($"-- {itemList}");
                }
            }
        }
    }
}
