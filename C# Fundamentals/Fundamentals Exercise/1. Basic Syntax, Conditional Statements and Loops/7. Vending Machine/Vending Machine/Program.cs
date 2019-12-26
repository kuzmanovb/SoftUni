using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string enter = Console.ReadLine();

            double moneyAll = 0;

            while (enter != "Start")
            {
                double money = double.Parse(enter);

                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    moneyAll += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }

                enter = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts" )
                {

                    if (moneyAll >= 2)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        moneyAll -= 2;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Water")
                {

                    if (moneyAll >= 0.7)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        moneyAll -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Crisps")
                {

                    if (moneyAll >= 1.5)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        moneyAll -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Soda")
                {
                    if (moneyAll >= 0.8)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        moneyAll -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Coke")
                {

                    if (moneyAll >= 1)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        moneyAll -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {moneyAll:f2}");
        }
    }
}
