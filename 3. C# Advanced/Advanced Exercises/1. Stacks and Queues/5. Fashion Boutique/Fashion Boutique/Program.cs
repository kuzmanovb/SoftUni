using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {

            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rackCapacity = int.Parse(Console.ReadLine());

            var box = new Stack<int>(clothes);

            int rackNumber = 1;
            int curentSum = 0;

            while (box.Any())
            {
                if (curentSum + box.Peek() <= rackCapacity)
                {
                    curentSum += box.Pop();
                }
                else
                {
                    rackNumber++;
                    curentSum = box.Pop();
                }
            }

            Console.WriteLine(rackNumber);
        }
    }
}
