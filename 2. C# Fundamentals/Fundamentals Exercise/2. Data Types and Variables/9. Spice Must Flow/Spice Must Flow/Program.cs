using System;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());

            int yield = 0;
            int day = 0;

            while (startYield >= 100)
            {
                yield += startYield;
                day++;
                if (yield >= 26)
                {
                    yield -= 26;
                }
                else
                {
                    yield -= yield;
                }
               
                startYield = startYield - 10;
            }

            if (yield >= 26)
            {
                yield -= 26;
            }
            else
            {
                yield -= yield;
            }

            Console.WriteLine(day);
            Console.WriteLine(yield);
        }
    }
}
