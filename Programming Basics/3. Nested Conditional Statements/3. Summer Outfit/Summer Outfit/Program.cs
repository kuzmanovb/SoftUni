using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string outfit = null;
            string shoes = null;

            if (degrees >= 10 && degrees <= 18)
            {
                    switch (timeOfDay)
                {
                    case "Morning": outfit = "Sweatshirt"; shoes = "Sneakers"; break;
                    case "Afternoon": outfit = "Shirt"; shoes = "Moccasins"; break;
                    case "Evening": outfit = "Shirt"; shoes = "Moccasins"; break;

                }
                
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (timeOfDay)
                {
                    case "Morning": outfit = "Shirt"; shoes = "Moccasins"; break;
                    case "Afternoon": outfit = "T-Shirt"; shoes = "Sandals"; break;
                    case "Evening": outfit = "Shirt"; shoes = "Moccasins"; break;

                }
            }
            else if (degrees >= 25)
            {
                switch (timeOfDay)
                {
                    case "Morning": outfit = "T-Shirt"; shoes = "Sandals"; break;
                    case "Afternoon": outfit = "Swim Suit"; shoes = "Barefoot"; break;
                    case "Evening": outfit = "Shirt"; shoes = "Moccasins"; break;

                }
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
