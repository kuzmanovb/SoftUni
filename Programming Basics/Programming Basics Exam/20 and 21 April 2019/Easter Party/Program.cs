using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guest = int.Parse(Console.ReadLine());
            double priceForOnePerson = double.Parse(Console.ReadLine());
            double buget = double.Parse(Console.ReadLine());


                if (guest >= 10 && guest <= 15)
                {
                priceForOnePerson = priceForOnePerson * 0.85;
                }
                else if (guest >= 16 && guest <= 20)
                {
                priceForOnePerson = priceForOnePerson * 0.80;
                }
                else if (guest >= 21)
                {
                priceForOnePerson = priceForOnePerson * 0.75;
                }

            double allPrice = (guest * priceForOnePerson) + (buget * 0.1);

            if (buget >= allPrice)
            {
                Console.WriteLine($"It is party time! {buget - allPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {allPrice - buget:f2} leva needed.");
            }


        }
    }
}
