using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopList = Console.ReadLine().Split().ToList();

            int numberCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommand; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Include")
                {
                    shopList.Add(input[1]);
                }
                if (input[0] == "Visit")
                {
                    int numberShopForRemove = int.Parse(input[2]);

                    if (numberShopForRemove <= shopList.Count)
                    {
                        if (input[1] == "first")
                        {
                            shopList.RemoveRange(0, numberShopForRemove);
                        }
                        else if (input[1] == "last")
                        {
                            int indexStart = shopList.Count - numberShopForRemove;
                            shopList.RemoveRange(indexStart, numberShopForRemove);
                        }
                    }
                }
                if (input[0] == "Prefer")
                {
                    int indexOne = int.Parse(input[1]);
                    int indexTwo = int.Parse(input[2]);


                    bool validateIndex = indexOne >= 0 && indexOne < shopList.Count && indexTwo >= 0 && indexTwo < shopList.Count;

                    if (validateIndex)
                    {
                        string shopOfIndexOne = shopList[indexOne];
                        string shopOfIndexTwo = shopList[indexTwo];

                        shopList[indexOne] = shopOfIndexTwo;
                        shopList[indexTwo] = shopOfIndexOne;
                    }
                }

                if (input[0] == "Place")
                {
                    int index = int.Parse(input[2]);
                    if (index >= 0 && index < shopList.Count)
                    {
                        shopList.Insert(index + 1, input[1]);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopList));
        }
    }
}
