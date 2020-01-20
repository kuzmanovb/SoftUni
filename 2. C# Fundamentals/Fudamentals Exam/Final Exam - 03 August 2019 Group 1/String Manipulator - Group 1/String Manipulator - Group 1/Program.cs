using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string enterText = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "Translate")
                {
                    char oldChar = char.Parse(commandArray[1]);
                    char newChar = char.Parse(commandArray[2]);

                    enterText = enterText.Replace(oldChar, newChar);
                    Console.WriteLine(enterText);
                }
                else if (commandArray[0] == "Includes")
                {
                    string forCheck = commandArray[1];
                    Console.WriteLine(enterText.Contains(forCheck));
                }
                else if (commandArray[0] == "Start")
                {
                    string forCheck = commandArray[1];
                    Console.WriteLine(enterText.StartsWith(forCheck));
                }
                else if (commandArray[0] == "Lowercase")
                {
                    enterText = enterText.ToLower();
                    Console.WriteLine(enterText);
                }
                else if (commandArray[0] == "FindIndex")
                {
                    char forChack = char.Parse(commandArray[1]);
                    Console.WriteLine(enterText.LastIndexOf(forChack));
                }
                else if (commandArray[0] == "Remove")
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int count = int.Parse(commandArray[2]);

                    enterText = enterText.Remove(startIndex, count);
                    Console.WriteLine(enterText);
                }
                               
                command = Console.ReadLine();
            }
        }
    }
}
