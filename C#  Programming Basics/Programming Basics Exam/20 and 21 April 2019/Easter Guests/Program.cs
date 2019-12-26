using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guest = int.Parse(Console.ReadLine());
            int buget = int.Parse(Console.ReadLine());

            double eggsForGuest = guest * 2.0;
            double easterBreadForGuest = Math.Ceiling(guest / 3.0);
            double allPrice = (eggsForGuest * 0.45) + (easterBreadForGuest * 4.0);

            if (buget >= allPrice)
            {
                Console.WriteLine($"Lyubo bought {easterBreadForGuest} Easter bread and {eggsForGuest} eggs.");
                Console.WriteLine($"He has {buget - allPrice:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {allPrice - buget:f2} lv. more.");
            }

        }
    }
}
