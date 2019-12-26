using System;

namespace Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWoker = int.Parse(Console.ReadLine());
            int woker = int.Parse(Console.ReadLine());
            int biscutsAnotherFactory = int.Parse(Console.ReadLine());

            int biscuitsForDay = woker * biscuitsPerWoker;

            double makeBiscuts = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    double lowBiscuits = Math.Floor(biscuitsForDay * 0.75);
                    makeBiscuts += lowBiscuits;
                }
                else
                {
                    makeBiscuts += biscuitsForDay;
                }
            }

            double procent = Math.Abs((makeBiscuts - biscutsAnotherFactory) / biscutsAnotherFactory * 100);

            Console.WriteLine($"You have produced {makeBiscuts} biscuits for the past month.");
            if (biscutsAnotherFactory < makeBiscuts)
            {
                Console.WriteLine($"You produce {procent:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {procent:f2} percent less biscuits.");
            }

        }
    }
}
