using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegetarianMenu = int.Parse(Console.ReadLine());

            double chickenPrice = chickenMenu * 10.35;
            double fishPrice = fishMenu * 12.40;
            double vegetarianPrice = vegetarianMenu * 8.15;

            double allPrice = chickenPrice + fishPrice + vegetarianPrice;
            double dessertPrice = allPrice * 0.20;

            Console.WriteLine($"Total: {allPrice + dessertPrice + 2.50:f2}");

        }
    }
}
