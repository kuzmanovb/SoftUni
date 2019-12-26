using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "exchange")
                {
                    int index = int.Parse(commandArray[1]);
                    Exchange(integerArray, index);
                }
                else if (commandArray[0] == "max")
                {
                    MaxEvenOrOdd(integerArray, commandArray[1]);
                }
                else if (commandArray[0] == "min")
                {
                    MinEvenOrOdd(integerArray, commandArray[1]);
                }
                else if (commandArray[0] == "first")
                {
                    int number = int.Parse(commandArray[1]);
                    FirstEvenOrOdd(integerArray, number, commandArray[2]);
                }
                else if (commandArray[0] == "last")
                {
                    int number = int.Parse(commandArray[1]);
                    LastEvenOrOdd(integerArray, number, commandArray[2]);
                }

                command = Console.ReadLine();
            }

            Console.Write("[");
            Console.Write(string.Join(", ", integerArray));
            Console.WriteLine("]");
        }

        static void Exchange(int[] name, int index)
        {
            int[] name = name;
            if (index > name.Length - 1 || index < 0)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                for (int i = 0; i <= index; i++)
                {
                    int firstNumber = name[0];

                    for (int a = 0; a < name.Length - 1; a++)
                    {
                        name[a] = name[a + 1];

                    }

                    name[name.Length - 1] = firstNumber;
                }

                name = name;
            }
        }

        static void MaxEvenOrOdd(int[] name, string evenOrOdd)
        {

            int index = 0;
            int bestNum = int.MinValue;
            int bestIndex = -1;

            if (evenOrOdd == "even")
            {
                foreach (var item in name)
                {
                    if (item % 2 == 0)
                    {
                        if (item >= bestNum)
                        {
                            bestNum = item;
                            bestIndex = index;
                        }
                    }
                    index++;
                }
            }
            else if (evenOrOdd == "odd")
            {
                foreach (var item in name)
                {
                    if (item % 2 != 0)
                    {
                        if (item >= bestNum)
                        {
                            bestNum = item;
                            bestIndex = index;
                        }
                    }
                    index++;
                }
            }

            if (bestIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(bestIndex);

            }
        }
        static void MinEvenOrOdd(int[] name, string evenOrOdd)
        {

            int index = 0;
            int bestNum = int.MaxValue;
            int bestIndex = -1;

            if (evenOrOdd == "even")
            {
                foreach (var item in name)
                {
                    if (item % 2 == 0)
                    {
                        if (item <= bestNum)
                        {
                            bestNum = item;
                            bestIndex = index;
                        }
                    }
                    index++;
                }
            }
            else if (evenOrOdd == "odd")
            {
                foreach (var item in name)
                {
                    if (item % 2 != 0)
                    {
                        if (item <= bestNum)
                        {
                            bestNum = item;
                            bestIndex = index;
                        }
                    }
                    index++;
                }
            }

            if (bestIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(bestIndex);

            }
        }

        static void FirstEvenOrOdd(int[] name, int count, string evenOrOdd)
        {
            List<int> firstEvenOrOdd = new List<int>();

            int stop = count;
            if (count > name.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (evenOrOdd == "even")
                {
                    foreach (var item in name)
                    {
                        if (item % 2 == 0)
                        {
                            firstEvenOrOdd.Add(item);
                            stop--;
                        }
                        if (stop == 0)
                        {

                            break;
                        }
                    }
                }
                else if (evenOrOdd == "odd")
                {
                    foreach (var item in name)
                    {
                        if (item % 2 != 0)
                        {
                            firstEvenOrOdd.Add(item);
                            stop--;
                        }
                        if (stop == 0)
                        {

                            break;
                        }
                    }
                }

                Console.Write("[");
                Console.Write(string.Join(", ", firstEvenOrOdd));
                Console.WriteLine("]");
            }
        }
        static void LastEvenOrOdd(int[] name, int count, string evenOrOdd)
        {
            List<int> lastEvenOrOdd = new List<int>();
            int stop = count;

            if (count > name.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {

                if (evenOrOdd == "even")
                {
                    for (int i = name.Length - 1; i >= 0; i--)
                    {

                        if (name[i] % 2 == 0)
                        {
                            lastEvenOrOdd.Add(name[i]);
                            stop--;
                        }
                        if (stop == 0)
                        {

                            break;
                        }
                    }
                }
                else if (evenOrOdd == "odd")
                {
                    for (int i = name.Length - 1; i >= 0; i--)
                    {
                        if (name[i] % 2 != 0)
                        {
                            lastEvenOrOdd.Add(name[i]);
                            stop--;
                        }
                        if (stop == 0)
                        {

                            break;
                        }
                    }
                }

                lastEvenOrOdd.Reverse();

                Console.Write("[");
                Console.Write(string.Join(", ", lastEvenOrOdd));
                Console.WriteLine("]");
            }
        }

    }
}
