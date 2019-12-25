using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int confectioners = int.Parse(Console.ReadLine());
            int cake = int.Parse(Console.ReadLine());
            int gofret = int.Parse(Console.ReadLine());
            int pancake = int.Parse(Console.ReadLine());
            double dayPrice = (cake * 45.0) + (gofret * 5.80) + ( pancake *3.20);
            double allPrice = (dayPrice * confectioners) * day;
            double price = allPrice - (allPrice / 8);
            Console.WriteLine($"{price:f2}");


        }
    }
}
