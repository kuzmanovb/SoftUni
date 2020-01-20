using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberKeg = int.Parse(Console.ReadLine());

            string keg = "";
            double bestVolume = 0;

            for (int i = 0; i < numberKeg; i++)
            {
                string modelKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double haight = double.Parse(Console.ReadLine());

                double volumeKeg = Math.PI * (radius * radius) * haight;

                if (volumeKeg > bestVolume)
                {
                    bestVolume = volumeKeg;
                    keg = modelKeg;
                }
            }

            Console.WriteLine(keg);
        }
    }
}
