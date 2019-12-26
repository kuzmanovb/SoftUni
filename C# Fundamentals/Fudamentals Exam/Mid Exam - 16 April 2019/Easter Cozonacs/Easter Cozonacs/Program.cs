using System;

namespace Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceOneFlour = double.Parse(Console.ReadLine());

            double packEggs = priceOneFlour * 0.75;
            double priceMilk250ml = (priceOneFlour * 1.25) / 4;

            double priceCozonac = priceOneFlour + packEggs + priceMilk250ml;

            int coloredAggs = 0;
            int countCozonac = 0;


            while (budget - priceCozonac >= 0)
            {
                budget -= priceCozonac;
                countCozonac++;
                coloredAggs += 3;
                if (countCozonac % 3 == 0)
                {
                    coloredAggs -= countCozonac - 2;
                }
            }

            Console.WriteLine($"You made {countCozonac} cozonacs! Now you have {coloredAggs} eggs and {budget:f2}BGN left.");
        }
    }
}
