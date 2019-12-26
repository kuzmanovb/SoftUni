using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSeries = Console.ReadLine();
            int timeEpisod = int.Parse(Console.ReadLine());
            int breakTime = int.Parse(Console.ReadLine());

            double timeForLunch = breakTime* 1.0 / 8;
            double relax = breakTime* 1.0 / 4;

            double needTame = breakTime - timeForLunch - relax;

            if (timeEpisod <= needTame)
            {
                Console.WriteLine($"You have enough time to watch {nameSeries} and left with {Math.Ceiling(needTame - timeEpisod)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {nameSeries}, you need {Math.Ceiling(timeEpisod - needTame)} more minutes.");
            }

        }
    }
}
