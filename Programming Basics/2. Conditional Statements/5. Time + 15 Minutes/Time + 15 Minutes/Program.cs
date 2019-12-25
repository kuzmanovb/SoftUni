using System;

namespace Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minuts = int.Parse(Console.ReadLine());

            int minutsAdd15 = minuts + 15;
            if (minutsAdd15 >= 60)
            {
                hours++;
                minutsAdd15 = minutsAdd15 - 60;
            }
            if (hours > 23)
            {
                hours = 0;

            }

            if (minutsAdd15 <= 9)
            {
                Console.WriteLine($"{hours}:0{minutsAdd15}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutsAdd15}");
            }

        }
    }
}
