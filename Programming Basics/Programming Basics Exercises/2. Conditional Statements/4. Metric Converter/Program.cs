using System;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double destination = double.Parse(Console.ReadLine());
            string unitIn = Console.ReadLine();
            string unitOut = Console.ReadLine();

            double destinationMilimet = 0.0;

            if (unitIn == "m")
            {
                destinationMilimet = destination * 1000.0;
            }
            else if (unitIn == "cm")
            {
                destinationMilimet = destination * 10.0;
            }
            else
            {
                destinationMilimet = destination;
            }

            if (unitOut == "m")
            {
                Console.WriteLine($"{destinationMilimet / 1000.0:f3}");
            }
            else if (unitOut == "cm")
            {
                Console.WriteLine($"{destinationMilimet / 10.0:f3}");
            }
            else
            {
                Console.WriteLine($"{destinationMilimet:f3}");
            }
        }
    }
}
