using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oscars_ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
           

            int rent = int.Parse(Console.ReadLine());
            double statuettes = rent * 0.7;
            double ketering = statuettes * 0.85;
            double saund = ketering / 2;
            double allPrice = rent + statuettes + ketering + saund;
            Console.WriteLine($"{allPrice:f2}");

        }
    }
}
