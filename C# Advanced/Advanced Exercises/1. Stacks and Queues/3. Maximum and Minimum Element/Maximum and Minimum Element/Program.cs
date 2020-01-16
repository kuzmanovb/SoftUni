using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                var commandArr = Console.ReadLine().Split();

                var command = commandArr[0];

                switch (command)
                {
                    case "1": 
                        stack.Push(int.Parse(commandArr[1]));
                        break;
                    case "2":
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;
                    case "3":
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case "4":
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
