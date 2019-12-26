using System;

namespace Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeSide = double.Parse(Console.ReadLine());
            int numbersPapers = int.Parse(Console.ReadLine());
            double areaListPaper = double.Parse(Console.ReadLine());

            double areaGiftBox = sizeSide * sizeSide * 6;

            double areaPaper = 0;

            for (int i = 1; i <= numbersPapers; i++)
            {
                if (i % 3 == 0)
                {
                    areaPaper += areaListPaper * 0.25;
                }
                else
                {
                    areaPaper += areaListPaper;
                }
            }

            double areaCover = areaPaper / (areaGiftBox / 100);

            Console.WriteLine($"You can cover {areaCover:f2}% of the box.");
        }
    }
}
