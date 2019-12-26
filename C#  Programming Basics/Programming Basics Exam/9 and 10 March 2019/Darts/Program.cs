using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();
            int point = 301;
            int shotSuccess = 0;
            int shotFall = 0;

            while (point >= 0)

            {
                if (0 == point)
                {
                    Console.WriteLine($"{namePlayer} won the leg with {shotSuccess} shots.");
                    break;
                }
                string field = Console.ReadLine();

                if (field == "Retire")
                {

                    Console.WriteLine($"{ namePlayer} retired after { shotFall} unsuccessful shots.");
                    break;
                }

                int pointsInHit = int.Parse(Console.ReadLine());

                int pointInHitAll = 0;

                if (field == "Single")
                {
                    pointInHitAll = pointsInHit;

                }
                else if (field == "Double")
                {
                    pointInHitAll = pointsInHit * 2;

                }
                else if (field == "Triple")
                {
                    pointInHitAll = pointsInHit * 3;

                }
                if (pointInHitAll <= point)
                {
                    point -= pointInHitAll;
                    shotSuccess++;
                }
                else
                {
                    shotFall++;
                }
            }
        }
    }
}
