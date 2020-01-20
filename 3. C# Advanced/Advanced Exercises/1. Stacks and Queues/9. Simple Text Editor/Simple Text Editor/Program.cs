using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOperation = int.Parse(Console.ReadLine());

            string text = "";

            var stackForReturn = new Stack<string>();

            for (int i = 0; i < numberOperation; i++)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "1")
                {
                    stackForReturn.Push(text);
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    stackForReturn.Push(text);
                    var startIndex = text.Length  - int.Parse(command[1]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (text.Length > 0)
                    {
                        text = text.Remove(startIndex);
                    }
                }
                else if (command[0] == "3")
                {
                    var index = int.Parse(command[1]) - 1;
                    if (index < text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }
                }
                else if (command[0] == "4" && stackForReturn.Any())
                {
                    text = stackForReturn.Pop();
                }
            }
        }
    }
}
