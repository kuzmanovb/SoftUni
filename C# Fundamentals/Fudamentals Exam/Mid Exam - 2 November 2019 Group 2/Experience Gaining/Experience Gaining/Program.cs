using System;

namespace Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double experienceAmount = double.Parse(Console.ReadLine());

            int countBattel = int.Parse(Console.ReadLine());

            double curentAmount = 0;
            int count = 0;
            bool check = false;

            for (int i = 1; i <= countBattel; i++)
            {
                double battel = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    battel *= 1.15;
                }
                if (i % 5 == 0)
                {
                    battel *= 0.90;
                }

                curentAmount += battel;
                count++;

                if (curentAmount >= experienceAmount)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {count} battles.");
            }
            else
            {
                double needExperiance = experienceAmount - curentAmount;
                Console.WriteLine($"Player was not able to collect the needed experience, {needExperiance:f2} more needed.");
            }
        }
    }
}
