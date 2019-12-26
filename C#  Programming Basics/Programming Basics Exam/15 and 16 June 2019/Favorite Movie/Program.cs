using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {

            int bestAscii = 0;
            string bestFilm = "";
            bool stop = true;

            for (int i = 0; i < 7; i++)
            {
                string nameFilm = Console.ReadLine();
                if (nameFilm == "STOP")
                {
                    stop = false;
                    break;
                }
                int asciiSum = 0;
                int nameLength = nameFilm.Length;
                foreach (int letter in nameFilm)
                {
                    if (letter > 64 && letter < 91)
                    {
                        asciiSum = asciiSum + (letter - nameLength);
                    }
                    else if (letter > 96 && letter < 123)
                    {
                        asciiSum = asciiSum + (letter - (nameLength * 2));
                    }
                    else
                    {
                        asciiSum = asciiSum + letter;
                    }
                }
                if (asciiSum > bestAscii)
                {
                    bestAscii = asciiSum;
                    bestFilm = nameFilm;
                }

            }

            if (stop)
            {
                Console.WriteLine("The limit is reached.");
            }

            Console.WriteLine($"The best movie for you is {bestFilm} with {bestAscii} ASCII sum.");
        }
    }
}
