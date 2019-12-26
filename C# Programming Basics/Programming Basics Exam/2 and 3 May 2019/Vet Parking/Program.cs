using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());

            double allSum = 0;

            for (int d = 1; d <= dayNumber; d++)
            {
                double priceForDay = 0;

                for (int h = 1; h <= hoursPerDay; h++)
                {
                    if (d % 2 == 0 && h % 2 != 0)
                    {
                        allSum += 2.50;
                        priceForDay += 2.50;
                    }
                    else if (d % 2 != 0 && h % 2 == 0)
                    {
                        allSum += 1.25;
                        priceForDay += 1.25;
                    }
                    else
                    {
                        allSum += 1;
                        priceForDay += 1;
                    }

                }
                Console.WriteLine($"Day: {d} - {priceForDay:f2} leva");
            }
            Console.WriteLine($"Total: {allSum:f2} leva");



        }
    }
}
