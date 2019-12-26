using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var allSum = new List<decimal>();

            string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                decimal number = int.Parse(item.Substring(1, item.Length - 2));
                char first = item[0];
                char end = item[item.Length - 1];
                decimal curentSum = 0;

                if (char.IsUpper(first))
                {
                    int charNumber = first - 64;
                    curentSum += number  / charNumber;
                }
                else if (char.IsLower(first))
                {
                    int charNumber = first - 96;
                    curentSum += number * charNumber;
                }

                if (char.IsUpper(end))
                {
                    int charNumber = end - 64;
                    curentSum -= charNumber;
                }
                else if (char.IsLower(end))
                {
                    int charNumber = end - 96;
                    curentSum += charNumber;
                }

                allSum.Add(curentSum);
            }

            decimal totalSum = 0;
            foreach (var item in allSum)
            {
                totalSum += item;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
