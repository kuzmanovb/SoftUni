using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|');

            List<int> allArray = new List<int>();

            for (int i = input.Length-1; i >= 0; i--)
            {
                int[] currentArray = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                allArray.AddRange(currentArray);
            }

            Console.WriteLine(string.Join(" ", allArray));
        }
    }
}
