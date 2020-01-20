using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            int buyEggs = 0;

            while (true)
            {
                string buyOrFill = Console.ReadLine();
                if (buyOrFill == "Close")
                {
                    Console.WriteLine("Store is closed!");
                    Console.WriteLine($"{buyEggs} eggs sold.");
                    break;
                }
                int eggsBuyOrFill = int.Parse(Console.ReadLine());

                if (buyOrFill == "Buy")
                {
                    if (eggs < eggsBuyOrFill)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggs}.");
                        break;
                    }
                    else
                    {
                        eggs -= eggsBuyOrFill;
                        buyEggs += eggsBuyOrFill;
                    }
                }
                else if (buyOrFill == "Fill")
                {
                    eggs += eggsBuyOrFill;
                }
            }
        }
    }
}
