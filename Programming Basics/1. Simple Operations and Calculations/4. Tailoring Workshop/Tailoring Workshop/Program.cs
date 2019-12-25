using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int table = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double widgh = double.Parse(Console.ReadLine());
            double areaClo = table * (lenght + 2 * 0.30) * (widgh + 2 * 0.30);
            double areaKar = table * (lenght / 2) * (lenght / 2);
            double priceUsa = areaClo * 7 + areaKar * 9;
            double priceBg = priceUsa * 1.85;
            Console.WriteLine($"{priceUsa:F2} USD");
            Console.WriteLine($"{priceBg:F2} BGN");


        }
    }
}
