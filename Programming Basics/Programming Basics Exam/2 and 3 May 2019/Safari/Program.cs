using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelLiter = double.Parse(Console.ReadLine());
            string deyInWeek = Console.ReadLine();

            double allPrice = (fuelLiter * 2.10) + 100;

            if (deyInWeek == "Saturday")
            {
                allPrice = allPrice * 0.9;
            }
            else if (deyInWeek == "Sunday")
            {
                allPrice = allPrice * 0.8;
            }

            if (budget >= allPrice)
            {
                Console.WriteLine($"Safari time! Money left: {budget-allPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {allPrice - budget:f2} lv.");
            }
        }
    }
}
