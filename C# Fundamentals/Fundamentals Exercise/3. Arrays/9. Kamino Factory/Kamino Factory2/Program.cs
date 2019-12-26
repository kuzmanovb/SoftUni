using System;
using System.Linq;

namespace Kamino_Factory2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthDna = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int[] bestDna = new int[lengthDna];
            int bestIndex = int.MaxValue; ;
            int bestSum = -1;
            int bestCount = -1;
            int count = 0;

            while (input != "Clone them!")
            {
                count++;
                int[] inputArray = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int curentIndex = int.MaxValue;
                int curentSum = inputArray.Sum();

                for (int i = 0; i < inputArray.Length-1; i++)
                {
                    if (inputArray[i] == 1 && inputArray[i+1] == 1)
                    {
                        if (curentIndex > i)
                        {
                            curentIndex = i;
                        }
                    }
                }

                if (bestIndex > curentIndex)
                {
                    bestIndex = curentIndex;
                    bestCount = count;
                    bestSum = curentSum;
                    bestDna = inputArray;
                }
                else if (bestIndex == curentIndex && bestSum < curentSum)
                {
                    bestCount = count;
                    bestSum = curentSum;
                    bestCount = count;
                    bestDna = inputArray;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestCount} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}
