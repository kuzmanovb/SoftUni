using System;
using System.Linq;

namespace Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allItem = Console.ReadLine().Split('|').ToArray();
            double budgetInput = double.Parse(Console.ReadLine());
            double budget = budgetInput;

            double[] price = new double[allItem.Length];

            double profit = 0;
            int count = 0;

            for (int i = 0; i < allItem.Length; i++)
            {
                string[] item = allItem[i].Split(new[] { "-", ">" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                double priceItem = double.Parse(item[1]);

                if (item[0] == "Clothes" && priceItem <= 50.00)
                {
                    if (budget - priceItem >= 0)
                    {
                        budget -= priceItem;
                        price[i] = priceItem * 1.4;
                        profit += priceItem * 0.4;
                        count++;
                    }
                }
                else if (item[0] == "Shoes" && priceItem <= 35.00)
                {
                    if (budget - priceItem >= 0)
                    {
                        budget -= priceItem;
                        price[i] = priceItem * 1.4;
                        profit += priceItem * 0.4;
                        count++;
                    }
                }
                else if (item[0] == "Accessories" && priceItem <= 20.50)
                {
                    if (budget - priceItem >= 0)
                    {
                        budget -= priceItem;
                        price[i] = priceItem * 1.4;
                        profit += priceItem * 0.4;
                        count++;
                    }
                }
            }

            for (int i = 0; i < price.Length; i++)
            {
                if (price[i] > 0)
                {
                    Console.Write($"{price[i]:f2} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");

            if (budgetInput + profit >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
