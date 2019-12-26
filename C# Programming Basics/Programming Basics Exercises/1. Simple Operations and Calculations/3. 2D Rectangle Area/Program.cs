using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double leight = Math.Abs(x1 - x2);
            double weght = Math.Abs(y1 - y2);
            double area = leight * weght;
            double perimeter = 2 * (leight + weght);
            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{perimeter:f2}");

        }
    }
}
