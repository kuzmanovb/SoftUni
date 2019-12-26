using System;
using System.Linq;
using System.Collections.Generic;

namespace Battle_Manager_whit_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Dictionary<string, HelthEnergy>();

            string input = Console.ReadLine();

            while (input != "Results")
            {
                string[] inputArr = input.Split(":");
                string command = inputArr[0];

                if (command == "Add")
                {
                    int helth = int.Parse(inputArr[2]);
                    int energy = int.Parse(inputArr[3]);

                    if (!person.ContainsKey(inputArr[1]))
                    {
                        person.Add(inputArr[1], new HelthEnergy(helth, energy));
                    }
                    else if (person.ContainsKey(inputArr[1]))
                    {
                        person[inputArr[1]].Helth += helth;
                    }
                }
                else if (command == "Attack")
                {
                    string attackName = inputArr[1];
                    string defenderName = inputArr[2];
                    int damage = int.Parse(inputArr[3]);

                    if (person.ContainsKey(attackName) && person.ContainsKey(defenderName))
                    {
                        person[defenderName].Helth -= damage;
                        if (person[defenderName].Helth <= 0)
                        {
                            person.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        person[attackName].Energy--;
                        if (person[attackName].Energy == 0)
                        {
                            person.Remove(attackName);
                            Console.WriteLine($"{attackName} was disqualified!");
                        }
                    }
                }
                else if (command == "Delete")
                {
                    if (inputArr[1] == "All")
                    {
                        person.Clear();
                    }
                    else if (person.ContainsKey(inputArr[1]))
                    {
                        person.Remove(inputArr[1]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"People count: {person.Count}");
            foreach (var item in person.OrderByDescending(x => x.Value.Helth).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value.Helth} - {item.Value.Energy}");
            }
        }
    }
    class HelthEnergy
    {
        public HelthEnergy(int helth, int energy)
        {
            Helth = helth;
            Energy = energy;
        }

        public int Helth { get; set; }
        public int Energy { get; set; }
    }
}
