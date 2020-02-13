using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newStack = new Stack<string>();

            var command = Console.ReadLine();

            while (command != "END")
            {
                if (command.StartsWith("Push"))
                {
                    var itemForAdd = command.Split(new char[] {' ', ',' } ,StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                    newStack.Push(itemForAdd);
                }
                else if (command == "Pop")
                {
                    if (!newStack.Any())
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                        newStack.Pop();
                    }
                }
                command = Console.ReadLine();
            }
            if (newStack.Any())
            {
                for (int i = 0; i < 2; i++)
                {

                    foreach (var item in newStack)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
