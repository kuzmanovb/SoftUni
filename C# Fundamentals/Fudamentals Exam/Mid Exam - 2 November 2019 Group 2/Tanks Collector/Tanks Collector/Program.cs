using System;
using System.Linq;

namespace Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            var tanksList = Console.ReadLine().Split(", ").ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string command = input[0];

                if (command == "Add")
                {
                    string tanksName = input[1];
                    if (tanksList.Contains(tanksName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        tanksList.Add(tanksName);
                        Console.WriteLine("Tank successfully bought");
                    }
                }
                else if (command == "Remove")
                {
                    string tanksName = input[1];

                    if (tanksList.Contains(tanksName))
                    {
                        tanksList.Remove(tanksName);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }
                else if (command == "Remove At")
                {
                    int index = int.Parse(input[1]);

                    bool validindex = index >= 0 && index < tanksList.Count;

                    if (!validindex)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else
                    {
                        tanksList.RemoveAt(index);
                        Console.WriteLine($"Tank successfully sold");
                    }
                }
                else if (command == "Insert")
                {

                    int index = int.Parse(input[1]);
                    string nameTank = input[2];

                    bool validindex = index >= 0 && index < tanksList.Count;

                    if (!validindex)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else
                    {
                        if (!tanksList.Contains(nameTank))
                        {
                            tanksList.Insert(index, nameTank);
                            Console.WriteLine("Tank successfully bought");
                        }
                        else
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", tanksList));
        }
    }
}
