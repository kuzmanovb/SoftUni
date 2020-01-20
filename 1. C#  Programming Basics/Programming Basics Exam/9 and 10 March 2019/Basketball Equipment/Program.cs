using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int tren = int.Parse(Console.ReadLine());
            double kez = tren * 0.6;
            double kit = kez * 0.8;
            double bols = kit / 4;
            double akses = bols / 5;
            double all = tren + kez + kit + bols + akses;
            Console.WriteLine($"{all:f2}");

        }
    }
}
