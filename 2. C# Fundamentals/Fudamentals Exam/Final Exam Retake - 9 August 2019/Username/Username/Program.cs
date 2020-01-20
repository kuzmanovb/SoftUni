using System;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] commandArr = command.Split();
                string curentCommand = commandArr[0];

                if (curentCommand == "Case")
                {
                    if (commandArr[1] == "lower")
                    {
                        input = input.ToLower();
                    }
                    else if (commandArr[1] == "upper")
                    {
                        input = input.ToUpper();
                    }
                    Console.WriteLine(input);
                }
                else if (curentCommand == "Reverse")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);

                    bool checkIndex = startIndex >= 0 && startIndex < input.Length && endIndex > startIndex && endIndex < input.Length;
                    if (checkIndex)
                    {
                        for (int i = endIndex; i >= startIndex; i--)
                        {
                            Console.Write(input[i]);
                        }
                        Console.WriteLine();
                    }
                }
                else if (curentCommand == "Cut")
                {
                    string substring = commandArr[1];

                    if (input.Contains(substring))
                    {
                        int startIndex = input.IndexOf(substring);
                        input = input.Remove(startIndex, substring.Length);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine($"The word {input} doesn't contain {substring}.");
                    }
                }
                else if (curentCommand == "Replace")
                {
                    char charInInput = char.Parse(commandArr[1]);

                    if (input.Contains(charInInput))
                    {
                        input = input.Replace(charInInput, '*');
                        Console.WriteLine(input);
                    }
                }
                else if (curentCommand == "Check")
                {
                    char charInInput = char.Parse(commandArr[1]);

                    if (input.Contains(charInInput))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {charInInput}.");
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
