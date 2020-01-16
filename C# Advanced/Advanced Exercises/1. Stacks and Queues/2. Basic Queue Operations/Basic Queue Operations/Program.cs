using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            var enqueueDequeueNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var inputNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(inputNumber);

            for (int i = 0; i < enqueueDequeueNumber[1]; i++)
            {
                var curentNumber = queue.Dequeue();
            }

            bool check = true;

            foreach (var number in queue)
            {
                if (number == enqueueDequeueNumber[2])
                {
                    Console.WriteLine("true");
                    check = false;
                }
            }

            if (check)
            {
                if (!queue.Any())
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
