using System;

namespace Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int step = int.Parse(Console.ReadLine());
            double lengthStep = double.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            double distanceTraveled = 0;

            for (int i = 1; i <= step; i++)
            {
                if (i % 5 == 0)
                {
                    distanceTraveled = distanceTraveled + (lengthStep * 0.7);
                }
                else
                {
                    distanceTraveled = distanceTraveled + lengthStep;
                }
            }

            double result = distanceTraveled / (distance * 100.0);

            Console.WriteLine($"You travelled { result * 100:f2}% of the distance!");
        }
    }
}
