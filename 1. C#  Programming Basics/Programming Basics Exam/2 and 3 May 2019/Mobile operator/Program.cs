using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractPeriod = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileInternet = Console.ReadLine();
            int monthNumber = int.Parse(Console.ReadLine());

            double contractPrice = 0;

            if (contractPeriod == "one")
            {
                switch (contractType)
                {
                    case "Small": contractPrice = 9.98; break;
                    case "Middle": contractPrice = 18.99; break;
                    case "Large": contractPrice = 25.98; break;
                    case "ExtraLarge": contractPrice = 35.99; break;
                }
            }
            else if (contractPeriod == "two")
            {
                switch (contractType)
                {
                    case "Small": contractPrice = 8.58; break;
                    case "Middle": contractPrice = 17.09; break;
                    case "Large": contractPrice = 23.59; break;
                    case "ExtraLarge": contractPrice = 31.79; break;
                }
            }

            if (mobileInternet == "yes")
            {
                if (contractPrice <= 10)
                {
                    contractPrice += 5.50;
                }
                else if (contractPrice > 10 && contractPrice <=30)
                {
                    contractPrice += 4.35;
                }
                else if (contractPrice > 30)
                {
                    contractPrice += 3.85;
                }
            }

            double allPrice = monthNumber * contractPrice;

            if (contractPeriod == "two")
            {
                allPrice = allPrice * 0.9625;
            }

            Console.WriteLine($"{allPrice:f2} lv.");

        }
    }
}
