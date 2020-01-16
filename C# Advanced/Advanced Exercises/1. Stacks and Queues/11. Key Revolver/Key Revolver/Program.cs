using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceBullet = int.Parse(Console.ReadLine());
            var sizeBarrel = int.Parse(Console.ReadLine());
            var bullet = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var intelligence = int.Parse(Console.ReadLine());

            var bulletStack = new Stack<int>(bullet);
            var locksQueue = new Queue<int>(locks);

            var countBullet = 0;
            while (bulletStack.Any() && locksQueue.Any())
            {

                var curentBullet = bulletStack.Pop();
                countBullet++;

                if (curentBullet <= locksQueue.Peek())
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countBullet % sizeBarrel == 0 && bulletStack.Any())
                {
                    Console.WriteLine("Reloading!");
                }

            }


            if (!bulletStack.Any() && locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                var bulletCost = countBullet * priceBullet;
                var profit = intelligence - bulletCost;
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${profit}");
            }
        }
    }
}
