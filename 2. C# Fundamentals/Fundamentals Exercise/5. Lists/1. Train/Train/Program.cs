using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();

            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] input = command.Split();

                if (input.Length == 2)
                {
                    train.Add(int.Parse(input[1]));
                }
                else
                {
                    int passengerAdd = int.Parse(input[0]);

                    for (int i = 0; i < train.Count; i++)
                    {
                        if (train[i] + passengerAdd <= capacity)
                        {
                            train.Insert(i, train[i] + passengerAdd);
                            train.RemoveAt(i + 1);
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
