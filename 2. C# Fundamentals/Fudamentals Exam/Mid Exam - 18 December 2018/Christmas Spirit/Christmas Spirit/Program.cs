﻿using System;

namespace Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double cost = 0;
            int spirit = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 2 == 0)
                {
                    cost += quantity * 2;
                    spirit += 5;
                }
                if (i % 3 == 0)
                {
                    cost += quantity * 5;
                    cost += quantity * 3;
                    spirit += 13;
                }
                if (i % 5 == 0)
                {
                    cost += quantity * 15;
                    spirit += 17;
                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }
                if (i % 10 == 0)
                {
                    spirit -= 20;
                    cost += 23;
                }
            }
            if (days % 10 == 0)
            {
                spirit -= 30;
            }

            Console.WriteLine($"Total cost: {cost}");
            Console.WriteLine($"Total spirit: {spirit}");

        }
    }
}
