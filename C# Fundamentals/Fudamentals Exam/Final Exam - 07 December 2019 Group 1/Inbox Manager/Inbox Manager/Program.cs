using System;
using System.Linq;
using System.Collections.Generic;

namespace Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "Statistics")
            {

                string[] commandArr = command.Split("->");
                string name = commandArr[1];

                if (commandArr[0] == "Add")
                {
                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already registered");
                    }
                }
                else if (commandArr[0] == "Send")
                {
                    string email = commandArr[2];

                    if (users.ContainsKey(name))
                    {
                        users[name].Add(email);
                    }
                }
                else if (commandArr[0] == "Delete")
                {
                    if (!users.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} not found!");
                    }
                    else
                    {
                        users.Remove(name);
                    }
                }

                command = Console.ReadLine();
            }


            Console.WriteLine($"Users count: {users.Keys.Count}");

            foreach (var item in users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var email in item.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
