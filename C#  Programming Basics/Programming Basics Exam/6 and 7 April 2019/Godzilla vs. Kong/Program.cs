using System;

namespace Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double dresPrice = double.Parse(Console.ReadLine());
            double decor = buget * 0.1;
            double dresAllPrice = 0;
            if (statist > 150)
            {
                dresAllPrice = (statist * dresPrice) * 0.9;
            }
            else
            {
                dresAllPrice = statist * dresPrice;
            }
            double allPrice = decor + dresAllPrice;

            if (buget >= allPrice)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {buget - allPrice:f2} leva left.");

            }
            else
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {allPrice - buget:f2} leva more.");
            }
        }
    }
}
