using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int day = int.Parse(Console.ReadLine());

            double price = 0;

            if (season == "Summer")
            {
                switch (destination)
                {
                    case "Dubai": price = 40000.0; break;
                    case "Sofia": price = 12500.0; break;
                    case "London": price = 20250.0; break;
                  
                }

            }
            else if (season == "Winter")
            {
                switch (destination)
                {
                    case "Dubai": price = 45000.0; break;
                    case "Sofia": price = 17000.0; break;
                    case "London": price = 24000.0; break;

                }

            }

            double priceForFilm = day * price;

            if (destination == "Dubai")
            {
                priceForFilm *= 0.7;
            }
            else if (destination == "Sofia")
            {
                priceForFilm *= 1.25;
            }

            if (budget >= priceForFilm)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {(budget - priceForFilm):f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {priceForFilm - budget:f2} leva more!");
            }

        }
    }
}
