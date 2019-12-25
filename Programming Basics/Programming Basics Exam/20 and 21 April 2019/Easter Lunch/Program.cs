using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreadLot = int.Parse(Console.ReadLine());
            int eggsCrust = int.Parse(Console.ReadLine());
            int bicuit = int.Parse(Console.ReadLine());

            int eggs = eggsCrust * 12;

            double allPrice = (easterBreadLot * 3.20) + (eggsCrust * 4.35) + (bicuit * 5.40) + (eggs * 0.15);

            Console.WriteLine($"{allPrice:f2}");

        }
    }
}
