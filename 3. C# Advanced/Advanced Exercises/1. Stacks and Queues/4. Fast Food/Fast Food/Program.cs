using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            var clientsOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(clientsOrders);

            while (queue.Any())
            {
                if (quantityFood < queue.Peek())
                {
                    break;
                }
                var order = queue.Dequeue();
                quantityFood -= order;
            }

            Console.WriteLine(clientsOrders.Max());
            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                var leftOrders = string.Join(" ", queue);
                Console.WriteLine("Orders left: " + leftOrders);
            }
        }
    }
}
