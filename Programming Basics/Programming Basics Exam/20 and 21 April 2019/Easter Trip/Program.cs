using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string date = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());

            double price = 0;

            if (destination == "France")
            {
                switch (date)
                {
                    case "21-23": price = 30.00; break;
                    case "24-27": price = 35.00; break;
                    case "28-31": price = 40.00; break;
                }

            }
            else if (destination == "Italy")
            {
                switch (date)
                {
                    case "21-23": price = 28.00; break;
                    case "24-27": price = 32.00; break;
                    case "28-31": price = 39.00; break;
                }

            }
            else if (destination == "Germany")
            {
                switch (date)
                {
                    case "21-23": price = 32.00; break;
                    case "24-27": price = 37.00; break;
                    case "28-31": price = 43.00; break;
                }

            }

            Console.WriteLine($"Easter trip to {destination} : {numberOfNights * price:f2} leva.");



        }
    }
}
