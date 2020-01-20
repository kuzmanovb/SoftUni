using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var forceBook = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] inputArr = input.Split(" | ");
                string[] inputArr1 = input.Split(" -> ");

                if (inputArr.Length > 1)
                {
                    string forceSide = inputArr[0];
                    string forceUser = inputArr[1];
                    bool checkUser = false;

                    foreach (var user in forceBook)
                    {
                        if (user.Value.Contains(forceUser))
                        {
                            checkUser = true;
                        }
                    }

                    if (!checkUser)
                    {
                        if (forceBook.ContainsKey(forceSide))
                        {

                            if (!forceBook[forceSide].Contains(forceUser))
                            {
                                forceBook[forceSide].Add(forceUser);
                            }
                        }
                        else
                        {
                            forceBook.Add(forceSide, new List<string> { forceUser });
                        }
                    }
                }
                else if (inputArr1.Length > 1)
                {
                    string forceUser = inputArr1[0];
                    string forceSide = inputArr1[1];

                    foreach (var item in forceBook)
                    {
                        if (item.Value.Contains(forceUser))
                        {
                            item.Value.Remove(forceUser);
                        }
                    }

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string> { forceUser });
                    }
                    else
                    {
                        forceBook[forceSide].Add(forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            forceBook = forceBook.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in forceBook)
            {
                item.Value.Sort();
            }

            foreach (var item in forceBook)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                }
                foreach (var member in item.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
