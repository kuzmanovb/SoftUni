using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForOneMet = double.Parse(Console.ReadLine());

            double delay = Math.Floor((distance / 15)) * 12.5;
            double timePlayer = (distance * timeForOneMet) + delay;

            if (timePlayer < record )
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {timePlayer:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {timePlayer - record:f2} seconds slower.");
            }

        }
    }
}
