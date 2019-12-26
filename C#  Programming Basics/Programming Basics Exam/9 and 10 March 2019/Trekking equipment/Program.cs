using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trekking_equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int alpinist = int.Parse(Console.ReadLine());
            int karabiners = int.Parse(Console.ReadLine());
            int rope = int.Parse(Console.ReadLine());
            int picel = int.Parse(Console.ReadLine());

            double allPrice = ((karabiners * 36) + (rope * 3.60) + (picel * 19.80)) * 1.20;

            Console.WriteLine($"{allPrice * alpinist:f2}");

        }
    }
}
