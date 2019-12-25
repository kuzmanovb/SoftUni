using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secoundTime = int.Parse(Console.ReadLine());
            int thardTime = int.Parse(Console.ReadLine());

            int allTime = firstTime + secoundTime + thardTime;

            int minuts = allTime / 60;
            int seconds = allTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minuts}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minuts}:{seconds}");
            }
        }
    }
}
