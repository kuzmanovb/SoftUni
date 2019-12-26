using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double wiskyPrice = double.Parse(Console.ReadLine());
            double beerLitre = double.Parse(Console.ReadLine());
            double wineLitre = double.Parse(Console.ReadLine());
            double rakiaLitre = double.Parse(Console.ReadLine());
            double wiskyLitre = double.Parse(Console.ReadLine());
            double rakiaPrice = wiskyPrice / 2;
            double beerPrice = rakiaPrice - (0.8 * rakiaPrice);
            double winePrice = rakiaPrice - (0.4 * rakiaPrice);
            double allPrice = (wiskyPrice * wiskyLitre) + (beerPrice * beerLitre) + (winePrice * wineLitre) + (rakiaPrice * rakiaLitre);
            Console.WriteLine($"{allPrice:f2}");

        }
    }
}
