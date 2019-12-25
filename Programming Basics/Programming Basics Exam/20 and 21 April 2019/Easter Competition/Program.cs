using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBread = int.Parse(Console.ReadLine());

            string nameBestBaker = null;
            int bestPoint = 0;

            for (int i = 0; i < easterBread; i++)
            {
                string baker = Console.ReadLine();
                int point = 0;

                while (true)
                {
                    string ratingString = Console.ReadLine();
                    if (ratingString == "Stop")
                    {
                        Console.WriteLine( $"{baker} has {point} points.");
                        if (point > bestPoint)
                        {
                            bestPoint = point;
                            nameBestBaker = baker;
                            Console.WriteLine($"{nameBestBaker} is the new number 1!");
                        }
                        break;
                    }

                    int rating = int.Parse(ratingString);
                    point += rating;

                }
            }
            Console.WriteLine($"{nameBestBaker} won competition with {bestPoint} points!");

        }
    }
}
