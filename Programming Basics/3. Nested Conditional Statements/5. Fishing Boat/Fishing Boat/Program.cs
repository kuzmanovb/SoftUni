using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int buget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenLot = int.Parse(Console.ReadLine());

            double boatPrice = 0;

            switch (season)
            {
                case "Spring": boatPrice = 3000;break;
                case "Summer":
                case "Autumn": boatPrice = 4200; break;
                case "Winter": boatPrice = 2600; break;
            }
            if (fishermenLot <= 6)
            {
                boatPrice = boatPrice * 0.9;
            }
            else if (fishermenLot > 6 && fishermenLot <= 11)
            {
                boatPrice = boatPrice * 0.85;
            }
            else if (fishermenLot >= 12)
            {
                boatPrice = boatPrice * 0.75;
            }

            if (fishermenLot % 2 == 0 && season != "Autumn")
            {
                boatPrice = boatPrice * 0.95;
            }

            if (buget >= boatPrice)
            {
                Console.WriteLine($"Yes! You have {buget - boatPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {boatPrice - buget:f2} leva.");
            }



        }
    }
}
