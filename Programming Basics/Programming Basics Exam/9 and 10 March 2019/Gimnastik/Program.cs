using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnastik
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont = Console.ReadLine().ToLower();
            string instru = Console.ReadLine().ToLower();
            double point = 0;
            if (cont == "russia")
            {
                if (instru == "ribbon")
                {
                    point = 18.500;
                    Console.WriteLine("The team of Russia get 18.500 on ribbon.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else if (instru == "hoop")
                {
                    point = 19.100;
                    Console.WriteLine("The team of Russia get 19.100 on hoop.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else if (instru == "rope")
                {
                    point = 18.600;
                    Console.WriteLine("The team of Russia get 18.600 on rope.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else
                {
                    Console.WriteLine("Incorrect appliance");
                }
            }
            else if (cont == "bulgaria")
            {
                if (instru == "ribbon")
                {
                    point = 19.000;
                    Console.WriteLine("The team of Bulgaria get 19.000 on ribbon.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else if (instru == "hoop")
                {
                    point = 19.300;
                    Console.WriteLine("The team of Bulgaria get 19.300 on hoop.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else if (instru == "rope")
                {
                    point = 18.900;
                    Console.WriteLine("The team of Bulgaria get 18.900 on rope.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else
                {
                    Console.WriteLine("Incorrect appliance");
                }
            }
            else if (cont == "italy")
            {
                if (instru == "ribbon")
                {
                    point = 18.700;
                    Console.WriteLine("The team of Italy get 18.700 on ribbon.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else if (instru == "hoop")
                {
                    point = 18.800;
                    Console.WriteLine("The team of Italy get 18.800 on hoop.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else if (instru == "rope")
                {
                    point = 18.900;
                    Console.WriteLine("The team of Italy get 18.850 on rope.");
                    Console.WriteLine("{0:f2} %", ((20 - point) / 20) * 100);
                }
                else
                {
                    Console.WriteLine("Incorrect appliance");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Country");
            }
        }
    }
}
