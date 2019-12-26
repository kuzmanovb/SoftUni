using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usa = double.Parse(Console.ReadLine());
            double lev = usa * 1.79549;
            Console.WriteLine($"{lev:f2}");
        }
    }
}
