using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Premiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFilm = Console.ReadLine();
            string pacetFilm = Console.ReadLine();
            int tiketNumber = int.Parse(Console.ReadLine());

            double pacetPrice = 0;

            if (nameFilm == "John Wick")
            {
                switch (pacetFilm)
                {
                    case "Drink": pacetPrice =  12.00; break;
                    case "Popcorn": pacetPrice =  15.00; break;
                    case "Menu": pacetPrice =  19.00; break;
                    
                }

            }
            else if (nameFilm == "Star Wars")
            {
                switch (pacetFilm)
                {
                    case "Drink": pacetPrice =  18.00; break;
                    case "Popcorn": pacetPrice =  25.00; break;
                    case "Menu": pacetPrice =  30.00; break;

                }

            }
            else if (nameFilm == "Jumanji")
            {
                switch (pacetFilm)
                {
                    case "Drink": pacetPrice =  9.00; break;
                    case "Popcorn": pacetPrice =  11.00; break;
                    case "Menu": pacetPrice =  14.00; break;

                }

            }

            double allPrice = tiketNumber * pacetPrice;

            if (nameFilm == "Star Wars" && tiketNumber >= 4)
            {
                allPrice = allPrice * 0.7;
            }

            if (nameFilm == "Jumanji" && tiketNumber == 2)
            {
                allPrice = allPrice * 0.85;
            }


            Console.WriteLine($"Your bill is {allPrice:f2} leva.");

        }
    }
}
