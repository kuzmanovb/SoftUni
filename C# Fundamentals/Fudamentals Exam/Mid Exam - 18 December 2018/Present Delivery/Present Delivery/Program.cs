using System;
using System.Linq;

namespace Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] house = Console.ReadLine().Split("@").Select(int.Parse).ToArray();

            string jump = Console.ReadLine();

            int numberOfHouses = house.Length;
            int indexSanta = 0;


            while (jump != "Merry Xmas!")
            {
                string[] jumpArray = jump.Split();

                int jumpLength = int.Parse(jumpArray[1]);
                int jumpIndex = indexSanta + jumpLength;

                while (jumpIndex > numberOfHouses - 1)
                {
                    jumpIndex -= numberOfHouses;
                }


                int peopleInHouse = house[jumpIndex];

                if (peopleInHouse > 0)
                {
                    house[jumpIndex] = peopleInHouse - 2;
                }
                else
                {
                    Console.WriteLine($"House {jumpIndex} will have a Merry Christmas.");
                }

                indexSanta = jumpIndex;

                jump = Console.ReadLine();
            }



            Console.WriteLine($"Santa's last position was {indexSanta}.");

            int count = 0;
            bool finish = true;

            foreach (var peopleInRoom in house)
            {
                if (peopleInRoom > 0)
                {
                    count++;
                    finish = false;
                }
            }

            if (finish)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {count} houses.");
            }
        }
    }
}
