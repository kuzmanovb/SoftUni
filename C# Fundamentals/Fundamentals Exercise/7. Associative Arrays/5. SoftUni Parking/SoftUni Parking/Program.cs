using System;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommand = int.Parse(Console.ReadLine());

            var parking = new Dictionary<string, string>();

            for (int i = 0; i < numberCommand; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[1];

                if (input[0] == "register")
                {
                    string number = input[2];
                    
                    if (parking.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[name]}");
                    }
                    else
                    {
                        parking.Add(name, number);
                        Console.WriteLine($"{name} registered {number} successfully");
                    }
                }
                else if (input[0] == "unregister")
                {
                    if (!parking.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        parking.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }
    }
}
