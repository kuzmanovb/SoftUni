using System;

namespace Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string hall = Console.ReadLine().ToLower();
            int ticket = int.Parse(Console.ReadLine());
            double price = 0;
            if (movie == "A Star Is Born")
            {
                if (hall == "normal")
                {
                    price = 7.50;
                }
                else if (hall == "luxury")
                {
                    price = 10.5;
                }
                else if (hall == "ultra luxury")
                {
                    price = 13.5;
                }
            }
            else if (movie == "Bohemian Rhapsody")
            {
                if (hall == "normal")
                {
                    price = 7.35;
                }
                else if (hall == "luxury")
                {
                    price = 9.45;
                }
                else if (hall == "ultra luxury")
                {
                    price = 12.75;
                }
            }
            else if (movie == "Green Book")
            {
                if (hall == "normal")
                {
                    price = 8.15;
                }
                else if (hall == "luxury")
                {
                    price = 10.25;
                }
                else if (hall == "ultra luxury")
                {
                    price = 13.25;
                }
            }
            else if (movie == "The Favourite")
            {
                if (hall == "normal")
                {
                    price = 8.75;
                }
                else if (hall == "luxury")
                {
                    price = 11.55;
                }
                else if (hall == "ultra luxury")
                {
                    price = 13.95;
                }
            }

            double allPrice = ticket * price;

            Console.WriteLine($"{movie} -> {allPrice:f2} lv.");
        }
    }
}
