using System;

namespace The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterForOne = double.Parse(Console.ReadLine());
            double foodForOne = double.Parse(Console.ReadLine());


            double waterForDay = players * waterForOne;
            double foodForDay = players * foodForOne;

            double allNeedWater = waterForDay * days;
            double allNeedFood = foodForDay * days;
            bool end = false;

            for (int i = 1; i <= days; i++)
            {
                energy -= double.Parse(Console.ReadLine());
                if (energy <= 0)
                {
                    end = true;
                    break;
                }

                if (i % 2 == 0)
                {
                    energy += energy * 0.05;
                    allNeedWater -= allNeedWater * 0.3;
                }
                if (i % 3 == 0)
                {
                    energy += energy * 0.1;
                    allNeedFood -= allNeedFood / players;
                }
            }

            if (end)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {allNeedFood:f2} food and {allNeedWater:f2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
        }
    }
}
