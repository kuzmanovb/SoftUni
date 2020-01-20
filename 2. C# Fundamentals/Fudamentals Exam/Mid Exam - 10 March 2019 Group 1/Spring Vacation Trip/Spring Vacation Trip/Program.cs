using System;

namespace Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupPeople = int.Parse(Console.ReadLine());
            double priceFuelKilometer = double.Parse(Console.ReadLine());
            double foodPriceForPerson = double.Parse(Console.ReadLine());
            double roomPriceForPerson = double.Parse(Console.ReadLine());

            bool stop = false;

            if (groupPeople > 10)
            {
                roomPriceForPerson *= 0.75;
            }

            double priceForFoodEdnHotel = (foodPriceForPerson * groupPeople * daysTrip) + (roomPriceForPerson * groupPeople * daysTrip);

            double curentExpens = priceForFoodEdnHotel;

            for (int i = 1; i <= daysTrip; i++)
            {
                double travelDistance = double.Parse(Console.ReadLine());

                double priceForFuelDay = travelDistance * priceFuelKilometer;
                curentExpens += priceForFuelDay;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    curentExpens += (0.4 * curentExpens);
                }

                if (i % 7 == 0)
                {
                    curentExpens -= (curentExpens / groupPeople);
                }

                if (budget < curentExpens)
                {
                    stop = true;
                    break;
                }

            }

            if (stop || budget < curentExpens)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {Math.Abs(curentExpens - budget):f2}$ more.");
            }
            else
            {
                Console.WriteLine($"You have reached the destination. You have {budget - curentExpens:f2}$ budget left.");
            }
        }
    }
}
