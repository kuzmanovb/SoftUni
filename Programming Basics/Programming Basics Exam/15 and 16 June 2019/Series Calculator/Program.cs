using System;

namespace Series_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSerial = Console.ReadLine();
            int sesonNumber = int.Parse(Console.ReadLine());
            int seriesNumber = int.Parse(Console.ReadLine());
            double timeSeries = double.Parse(Console.ReadLine());

            double timeSeriesWithReclam = timeSeries * 1.20;
            double allTimeSeason = timeSeriesWithReclam * seriesNumber * sesonNumber;

            double allTime = allTimeSeason + (sesonNumber * 10);

            Console.WriteLine($"Total time needed to watch the {nameSerial} series is {Math.Round(allTime)} minutes.");

        }
    }
}
