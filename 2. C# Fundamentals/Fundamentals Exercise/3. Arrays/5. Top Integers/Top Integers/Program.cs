using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 1; i < numbers.Length; i++)
            {
                int topInteger = numbers[i - 1];
                int numberBig = 0;

                for (int y = i; y < numbers.Length; y++)
                {
                    int num = numbers[y];
                    if (numberBig < num)
                    {
                        numberBig = num;
                    }

                }
                if (topInteger > numberBig)
                {
                    Console.Write(topInteger + " ");
                }
                numberBig = 0;

            }
            Console.WriteLine(numbers[numbers.Length - 1]);
        }
    }
}
