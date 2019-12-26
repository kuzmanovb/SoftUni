using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double earnings = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double earningsMin = double.Parse(Console.ReadLine());

            if (earnings <= earningsMin && averageSuccess >= 4.50)
            {
                if (averageSuccess >= 5.50)
                {
                    if (Math.Floor(earningsMin * 0.35) <= Math.Floor(averageSuccess * 25))
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(averageSuccess * 25)} BGN");
                    }
                    else if (Math.Floor(earningsMin * 0.35) > Math.Floor(averageSuccess * 25))
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Floor(earningsMin * 0.35)} BGN");
                    }
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(earningsMin * 0.35)} BGN");
                }
            }
            else if (earnings > earningsMin && averageSuccess >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(averageSuccess * 25)} BGN");
            }
            else
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
        }
    }
}
