using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            double people = row * col;

            if (projection == "Premiere")
            {
                Console.WriteLine($"{people * 12.00:f2} leva.");
            }
            else if (projection == "Normal")
            {
                Console.WriteLine($"{people * 7.50:f2} leva.");
            }
            else if (projection == "Discount")
            {
                Console.WriteLine($"{people * 5.00:f2} leva.");
            }
        }
    }
}
