using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cupsQueue = new Queue<int>(cups);
            var bottlesStack = new Stack<int>(bottles);

            int wastedWater = 0;

            while (cupsQueue.Any() && bottlesStack.Any())
            {
                int curentCup = cupsQueue.Dequeue();
                while (curentCup > 0)
                {
                    curentCup -= bottlesStack.Pop();
                    if (curentCup < 0)
                    {
                        wastedWater += Math.Abs(curentCup);
                    }
                }
            }

            if (cupsQueue.Any())
            {
                string cupsForPrint = string.Join(" ", cupsQueue);
                Console.WriteLine($"Cups: {cupsForPrint}");
            }
            else
            {
                string bottleForPrint = string.Join(" ", bottlesStack);
                Console.WriteLine($"Bottles: {bottleForPrint}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
