using System;
using System.Linq;

namespace String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string inputCommand = Console.ReadLine();

            while (inputCommand != "Done")
            {
                string[] inputArr = inputCommand.Split();
                string command = inputArr[0];

                if (command == "Change")
                {
                    char forChange = char.Parse(inputArr[1]);
                    char toChange = char.Parse(inputArr[2]);

                    inputString = inputString.Replace(forChange, toChange);
                    Console.WriteLine(inputString);
                }
                else if (command == "Includes")
                {
                    string forCheck = inputArr[1];

                    Console.WriteLine(inputString.Contains(forCheck));

                }
                else if (command == "End")
                {
                    string forCheck = inputArr[1];

                    Console.WriteLine(inputString.EndsWith(forCheck));

                }
                else if (command == "Uppercase")
                {

                    inputString = inputString.ToUpper();
                    Console.WriteLine(inputString);
                }
                else if (command == "FindIndex")
                {
                    char findChange = char.Parse(inputArr[1]);

                    Console.WriteLine(inputString.IndexOf(findChange));
                }
                else if (command == "Cut")
                {
                    int start = int.Parse(inputArr[1]);
                    int lenght = int.Parse(inputArr[2]);

                    string cutstring = inputString.Substring(start, lenght);
                    inputString = inputString.Remove(start, lenght);
                    Console.WriteLine(cutstring);
                }

                inputCommand = Console.ReadLine();
            }
        }
    }
}
