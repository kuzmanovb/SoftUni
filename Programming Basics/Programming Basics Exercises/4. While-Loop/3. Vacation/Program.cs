using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string seaoson = Console.ReadLine();

            double price = 0;
            string place = "";
            string location = "";

            if (budget <= 1000)
            {
                place = "Camp";
                if (seaoson == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.65;
                }
                else if (seaoson == "Winter")
                {
                    location = "Morocco";
                    price = budget * 0.45;
                }

            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";
                if (seaoson == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.8;
                }
                else if (seaoson == "Winter")
                {
                    location = "Morocco";
                    price = budget * 0.60;
                }

            }
            else if (budget > 3000)
            {
                place = "Hotel";
                if (seaoson == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.9;
                }
                else if (seaoson == "Winter")
                {
                    location = "Morocco";
                    price = budget * 0.9;
                }

            }

            Console.WriteLine($"{location} - {place} - {price:f2}");

        }
    }
}
