using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForPicture = int.Parse(Console.ReadLine());
            int numberSceni = int.Parse(Console.ReadLine());
            int timeSceni = int.Parse(Console.ReadLine());

            double timeForTeren = timeForPicture * 0.15;

            double timeForWork = (numberSceni * timeSceni) + timeForTeren;

            if (timeForPicture >= timeForWork)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeForPicture - timeForWork)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(timeForWork - timeForPicture)} minutes.");
            }
        }
    }
}
