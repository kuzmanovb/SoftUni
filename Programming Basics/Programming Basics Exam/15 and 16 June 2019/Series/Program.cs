using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberSerial = int.Parse(Console.ReadLine());

            double allPrice = 0;

            for (int i = 1; i <= numberSerial; i++)
            {
                string nameSerial = Console.ReadLine();
                double priceSerial = double.Parse(Console.ReadLine());

                if (nameSerial == "Thrones")
                {
                    allPrice = allPrice + (priceSerial * 0.5);
                }
                else if (nameSerial == "Lucifer")
                {
                    allPrice = allPrice + (priceSerial * 0.6);
                }
                else if (nameSerial == "Protector")
                {
                    allPrice = allPrice + (priceSerial * 0.7);
                }
                else if (nameSerial == "TotalDrama")
                {
                    allPrice = allPrice + (priceSerial * 0.8);
                }
                else if (nameSerial == "Area")
                {
                    allPrice = allPrice + (priceSerial * 0.9);
                }
                else
                {
                    allPrice = allPrice + priceSerial;
                }

            }

            if (budget >= allPrice)
            {
                Console.WriteLine($"You bought all the series and left with {(budget - allPrice):f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {(allPrice - budget):f2} lv. more to buy the series!");
            }



        }
    }
}
