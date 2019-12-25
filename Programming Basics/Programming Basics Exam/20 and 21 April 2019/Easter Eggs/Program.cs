using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsNumber = int.Parse(Console.ReadLine());

            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;

            for (int i = 0; i < eggsNumber; i++)
            {
                string color = Console.ReadLine();
                switch (color)
                {
                    case "red": red++; break;
                    case "orange": orange++; break;
                    case "blue": blue++; break;
                    case "green": green++; break;
                   
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");

            if (red > orange && red > blue && red > green)
            {
                Console.WriteLine($"Max eggs: {red} -> red");
            }
            else if (orange > red && orange > blue && orange > green)
            {
                Console.WriteLine($"Max eggs: {orange} -> orange");
            }
            else if (blue > red && blue > orange && blue > green)
            {
                Console.WriteLine($"Max eggs: {blue} -> blue");
            }
            else if (green > red && green > orange && green > blue)
            {
                Console.WriteLine($"Max eggs: {green} -> green");
            }

        }
    }
}
