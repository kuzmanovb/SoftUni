using System;

namespace Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double targetPlunder = double.Parse(Console.ReadLine());

            double sumPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                sumPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    sumPlunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    sumPlunder = sumPlunder * 0.7; 
                }
            }

            if (targetPlunder <= sumPlunder)
            {
                Console.WriteLine($"Ahoy! {sumPlunder:f2} plunder gained.");
            }
            else
            {
                double lessPlunder = (100.0 / targetPlunder ) * sumPlunder;
                Console.WriteLine($"Collected only {lessPlunder:f2}% of the plunder.");
            }
        }
    }
}
