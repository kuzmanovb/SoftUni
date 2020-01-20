using System;

namespace Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Complete")
            {
                string[] commandArr = command.Split();

                if (commandArr[0] == "Make")
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
                else if (commandArr[0] == "GetDomain")
                {
                    int count = int.Parse(commandArr[1]);

                    Console.WriteLine(input.Substring(input.Length - count));
                }
                else if (commandArr[0] == "GetUsername")
                {

                    int index = input.IndexOf("@");

                    if (index == -1)
                    {
                        Console.WriteLine($"The email {input} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        Console.WriteLine(input.Substring(0, index));
                    }
                }
                else if (commandArr[0] == "Replace")
                {
                    char oldChar = char.Parse(commandArr[1]);
                    input = input.Replace(oldChar, '-');
                    Console.WriteLine(input);
                }
                else if (commandArr[0] == "Encrypt")
                {
                    foreach (var item in input)
                    {
                        Console.Write((int)item + " ");
                    }
                    Console.WriteLine();
                }
                command = Console.ReadLine();
            }
        }
    }
}
