using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var pushPopNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var inputNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(inputNumber);

            for (int i = 0; i < pushPopNumber[1]; i++)
            {
                var curentNumber = stack.Pop();
            }

            bool check = true;

            foreach (var number in stack)
            {
                if (number == pushPopNumber[2])
                {
                    Console.WriteLine("true");
                    check = false;
                }
            }

            if (check)
            {
                if (!stack.Any())
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
