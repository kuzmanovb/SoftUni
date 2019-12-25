using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerNumber = int.Parse(Console.ReadLine());
            int buget = int.Parse(Console.ReadLine());
            double flowerPrice = 0.0;

            switch (flowerType)
            {
                case "Roses": flowerPrice = 5.00;break;
                case "Dahlias": flowerPrice = 3.80;break;
                case "Tulips": flowerPrice = 2.80; break;
                case "Narcissus": flowerPrice = 3.00; break;
                case "Gladiolus": flowerPrice = 2.50; break;
            }

            double allPrice = flowerNumber * flowerPrice;

            if (flowerType == "Roses" && flowerNumber > 80)
            {
                allPrice = allPrice * 0.90;
            }
            else if (flowerType == "Dahlias" && flowerNumber > 90)
            {
                allPrice = allPrice * 0.85;
            }
            else if (flowerType == "Tulips" && flowerNumber > 80)
            {
                allPrice = allPrice * 0.85;
            }
            else if (flowerType == "Narcissus" && flowerNumber < 120)
            {
                allPrice = allPrice * 1.15;
            }
            else if (flowerType == "Gladiolus" && flowerNumber < 80)
            {
                allPrice = allPrice * 1.20;
            }

            if (buget >= allPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerNumber} { flowerType} and {buget - allPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {allPrice - buget:f2} leva more.");
            }

        }
    }
}
