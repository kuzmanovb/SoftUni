﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int s1 = a1; s1 < a2; s1++)
            {
                for (int s2 = 1; s2 < n; s2++)
                {
                    for (int s3 = 1; s3 < n/2; s3++)
                    {
                        if (s1 % 2 != 0 && (s2 + s3 + s1) % 2 != 0)
                        {
                           
                            Console.WriteLine($"{(char)s1}-{s2}{s3}{s1}");
                        }


                    }

                }

            }

        }
    }
}
