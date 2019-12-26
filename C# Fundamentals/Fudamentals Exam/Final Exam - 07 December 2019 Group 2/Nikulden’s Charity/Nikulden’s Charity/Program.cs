using System;

namespace Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] commandArr = command.Split();

                if (commandArr[0] == "Replace")
                {
                    char curentChar = char.Parse(commandArr[1]);
                    char newChar = char.Parse(commandArr[2]);

                    input = input.Replace(curentChar, newChar);
                    Console.WriteLine(input);
                }
                else if (commandArr[0] == "Cut")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);
                    int count = endIndex - startIndex + 1;

                    bool checkIndex = startIndex >= 0 && startIndex < input.Length && endIndex >= startIndex && endIndex < input.Length;

                    if (checkIndex)
                    {
                        input = input.Remove(startIndex, count);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (commandArr[0] == "Make")
                {
                    if (commandArr[1] == "Upper")
                    {
                        input = input.ToUpper();
                    }
                    else if (commandArr[1] == "Lower")
                    {
                        input = input.ToLower();
                    }
                    Console.WriteLine(input);
                }
                else if (commandArr[0] == "Check")
                {
                    string forCheck = commandArr[1];

                    if (input.Contains(forCheck))
                    {
                        Console.WriteLine($"Message contains {forCheck}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {forCheck}");
                    }

                }
                else if (commandArr[0] == "Sum")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);

                    bool checkIndex = startIndex >= 0 && startIndex < input.Length && endIndex >= 0 && endIndex < input.Length;

                    int sum = 0;
                    if (checkIndex)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += (int)input[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }


                }

                command = Console.ReadLine();
            }
        }
    }
}
