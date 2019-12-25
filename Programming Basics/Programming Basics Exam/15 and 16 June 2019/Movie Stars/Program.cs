using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            bool stop = false;

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "ACTION")
                {
                    break;
                }
                if (name.Length > 15)
                {
                    budget *= 0.8;
                }
                else
                {
                    double salary = double.Parse(Console.ReadLine());
                    budget -= salary;
                }
                if (budget < 0)
                {
                    stop = true;
                    break;
                }


            }
            if (stop)
            {
                Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
            }
            else
            {
                Console.WriteLine($"We are left with {budget:f2} leva.");
            }


        }
    }
}
