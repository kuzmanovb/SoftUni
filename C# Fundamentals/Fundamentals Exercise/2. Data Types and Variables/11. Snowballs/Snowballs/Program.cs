using System;
using System.Numerics;
using System.Collections.Concurrent;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {

            int game = int.Parse(Console.ReadLine());

            int bestSnow = 0;
            int bestTime = 0;
            double bestQuality = 0;
           BigInteger bestResult = 0;

            for (int i = 0; i < game; i++)
            {

                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int firstSum = snowballSnow / snowballTime;

               BigInteger result = BigInteger.Pow(firstSum,snowballQuality);

                if (result >= bestResult)
                {
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                    bestResult = result;
                }

            }

            Console.WriteLine($"{ bestSnow} : {bestTime} = {bestResult} ({ bestQuality})");


        }
    }
}
