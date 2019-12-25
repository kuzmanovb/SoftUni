using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBread = int.Parse(Console.ReadLine());

            double sugarAll = 0;
            double flourAll = 0;
            double sugarMax = 0;
            double flourMax = 0;

            for (int i = 0; i < easterBread; i++)
            {
                double sugar = double.Parse(Console.ReadLine());
                double flour = double.Parse(Console.ReadLine());
                if (sugarMax < sugar)
                {
                    sugarMax = sugar;
                }
                if (flourMax < flour )
                {
                    flourMax = flour;
                }
                sugarAll += sugar;
                flourAll += flour;
            }

            Console.WriteLine($"Sugar: {Math.Ceiling(sugarAll / 950)}");
            Console.WriteLine($"Flour: {Math.Ceiling(flourAll / 750)}");
            Console.WriteLine($"Max used flour is {flourMax} grams, max used sugar is {sugarMax} grams.");

        }
    }
}
