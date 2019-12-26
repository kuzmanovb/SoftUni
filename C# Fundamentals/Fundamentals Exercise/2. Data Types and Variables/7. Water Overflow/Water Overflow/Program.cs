using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int receiveLines = int.Parse(Console.ReadLine());

            int waterTank = 255;
            int litreInTank = 0;

            for (int i = 0; i < receiveLines; i++)
            {
                int pourTank = int.Parse(Console.ReadLine());

                if (pourTank <= waterTank)
                {
                    waterTank -= pourTank;
                    litreInTank += pourTank;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(litreInTank);
        }
    }
}
