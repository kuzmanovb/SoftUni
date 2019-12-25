using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceApart = 0;

            switch (month)
            {
                case "May":
                case "October":
                    priceStudio = 50.00; priceApart = 65.00;
                    break;
                case "June":
                case "September":
                    priceStudio = 75.20; priceApart = 68.70;
                    break;
                case "July":
                case "August":
                    priceStudio = 76.00; priceApart = 77.00;
                    break;
            }

            if (month == "May" || month == "October")
            {
                if (nights > 7 && nights <= 14)
                {
                    priceStudio = 50 * 0.95;
                }
                else if (nights > 14)
                {
                    priceStudio = 50 * 0.70;
                }
            }
            if (month == "June" || month == "September")
            {
                if (nights > 14)
                {
                    priceStudio = 75.20 * 0.80;
                }
            }
            if (nights > 14)
            {
                priceApart = priceApart * 0.90;
            }
            Console.WriteLine("Apartment: {0:f2} lv.", nights * priceApart);
            Console.WriteLine("Studio: {0:f2} lv.", nights * priceStudio);
        }
    }
}
