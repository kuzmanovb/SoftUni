﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histograma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1 += 1;
                }
                else if (num < 400)
                {
                    p2 += 1;
                }
                else if (num < 600)
                {
                    p3 += 1;
                }
                else if (num < 800)
                {
                    p4 += 1;
                }
                else
                {
                    p5 += 1;
                }
            }
            Console.WriteLine("{0:f2}%", (p1 / n) * 100);
            Console.WriteLine("{0:f2}%", (p2 / n) * 100);
            Console.WriteLine("{0:f2}%", (p3 / n) * 100);
            Console.WriteLine("{0:f2}%", (p4 / n) * 100);
            Console.WriteLine("{0:f2}%", (p5 / n) * 100);
        }
    }
}
