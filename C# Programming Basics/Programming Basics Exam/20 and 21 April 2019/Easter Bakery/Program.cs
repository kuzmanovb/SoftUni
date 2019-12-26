using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aster_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourLot = double.Parse(Console.ReadLine());
            double sugarLot = double.Parse(Console.ReadLine());
            int eggsLot = int.Parse(Console.ReadLine());
            int yeastLot = int.Parse(Console.ReadLine());

            double sugarPrice = flourPrice * 0.75;
            double eggsPrice = flourPrice * 1.1;
            double yeastPrice = sugarPrice * 0.2;

            double allPrice = (flourLot * flourPrice) + (sugarLot * sugarPrice) + (eggsLot * eggsPrice) + (yeastLot * yeastPrice);
            Console.WriteLine($"{allPrice:f2}");
        }
    }
}
