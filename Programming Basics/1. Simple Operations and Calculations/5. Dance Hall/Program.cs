using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double leighd = double.Parse(Console.ReadLine());
            double wighd = double.Parse(Console.ReadLine());
            double size = double.Parse(Console.ReadLine());
            double hallSize = (leighd * 100.0) * (wighd * 100.0);
            double wardrobe = (size * 100.0) * ( size * 100.0);
            double seat = hallSize / 10.0;
            double freeSize = hallSize - wardrobe - seat;
            double dencers = freeSize / (40.0 + 7000.0);
            Console.WriteLine(Math.Floor(dencers));

        }
    }
}
