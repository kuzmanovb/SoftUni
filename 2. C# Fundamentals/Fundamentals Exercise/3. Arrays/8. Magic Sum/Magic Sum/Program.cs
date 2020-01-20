using System;
using System.Linq;

namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int megicNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                int num1 = array[i];
                for (int a = i + 1; a < array.Length; a++)
                {
                    int sum = num1 + array[a];

                    if (sum == megicNumber)
                    {
                        Console.WriteLine(num1 + " " + array[a]);
                    }
                }
            }
        }
    }
}
