using System;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArray = input.Split();

                if (inputArray[0] == "Switch")
                {
                    int index = int.Parse(inputArray[1]);

                    bool indexValidate = index >= 0 && index < numbersArray.Length;

                    if (indexValidate)
                    {
                        int number = numbersArray[index];

                        if (number < 0)
                        {
                            number += Math.Abs(number * 2);
                        }
                        else if (number > 0)
                        {
                            number -= number * 2;
                        }
                        numbersArray[index] = number;
                    }
                }
                if (inputArray[0] == "Change")
                {
                    int index = int.Parse(inputArray[1]);
                    int number = int.Parse(inputArray[2]);

                    bool indexValidate = index >= 0 && index < numbersArray.Length;

                    if (indexValidate)
                    {
                        numbersArray[index] = number;
                    }
                }
                if (inputArray[1] == "Negative")
                {
                    int sum = 0;

                    foreach (var number in numbersArray)
                    {
                        if (number < 0)
                        {
                            sum += number;
                        }
                    }

                    Console.WriteLine(sum);
                }
                if (inputArray[1] == "Positive")
                {
                    int sum = 0;

                    foreach (var number in numbersArray)
                    {
                        if (number > 0)
                        {
                            sum += number;
                        }
                    }

                    Console.WriteLine(sum);
                }
                if (inputArray[1] == "All")
                {
                    int sum = 0;

                    foreach (var number in numbersArray)
                    {
                        sum += number;
                    }

                    Console.WriteLine(sum);
                }

                input = Console.ReadLine();
            }

            foreach (var number in numbersArray)
            {
                if (number >= 0)
                {
                    Console.Write(number + " ");
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
