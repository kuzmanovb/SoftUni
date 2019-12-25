using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberN = int.Parse(Console.ReadLine());
            int numberL = int.Parse(Console.ReadLine());

            for (int a = 1; a <= numberN; a++)
            {
                for (int b = 1; b <= numberN; b++)
                {
                    for (int c = 97; c <= 96+numberL; c++)
                    {
                        for (int d = 97; d <= 96 + numberL; d++)
                        {
                            for (int e = 1; e <= numberN; e++)
                            {
                                if (a < e && b < e)
                                {
                                    Console.Write($"{a}{b}{(char)c}{(char)d}{e} ");
                                }
                            }

                        }

                    }

                }

            }

        }
    }
}
