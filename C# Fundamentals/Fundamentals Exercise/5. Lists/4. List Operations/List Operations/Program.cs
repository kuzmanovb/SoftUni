using System;
using System.Linq;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOperations = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);
                    listOperations.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index < 0 || index > listOperations.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        listOperations.Insert(index, number);
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index < 0 || index > listOperations.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        listOperations.RemoveAt(index);
                    }
                }
                else if (command[0] == "Shift" && command[1] == "left")
                {
                    int move = int.Parse(command[2]);

                    for (int i = 0; i < move; i++)
                    {
                        int firstNum = listOperations[0];
                        listOperations.RemoveAt(0);
                        listOperations.Add(firstNum);
                    }
                }
                else if (command[0] == "Shift" && command[1] == "right")
                {
                    int move = int.Parse(command[2]);

                    for (int i = 0; i < move; i++)
                    {
                        int lastNum = listOperations[listOperations.Count - 1];
                        listOperations.RemoveAt(listOperations.Count - 1);
                        listOperations.Insert(0, lastNum);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", listOperations));

        }
    }
}
