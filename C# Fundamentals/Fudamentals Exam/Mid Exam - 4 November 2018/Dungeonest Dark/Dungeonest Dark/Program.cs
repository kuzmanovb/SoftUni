using System;

namespace Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|');

            int health = 100;
            int coins = 0;

            int bestRoom = 0;
            bool finish = true;

            foreach (var room in rooms)
            {
                string[] curentRoom = room.Split();
                bestRoom++;

                int curentDigit = int.Parse(curentRoom[1]);

                if (curentRoom[0] == "potion")
                {
                    if (health + curentDigit <= 100)
                    {
                        Console.WriteLine($"You healed for {curentDigit} hp.");
                        health += curentDigit;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        int subtractSum = (health + curentDigit) - 100;
                        curentDigit -= subtractSum;
                        Console.WriteLine($"You healed for {curentDigit} hp.");
                        health += curentDigit;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (curentRoom[0] == "chest")
                {
                    Console.WriteLine($"You found {curentDigit} coins.");
                    coins += curentDigit;
                }
                else
                {
                    health -= curentDigit;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {curentRoom[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {curentRoom[0]}.");
                        Console.WriteLine($"Best room: {bestRoom}");
                        finish = false;
                        break;
                    }
                }
            }

            if (finish)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
