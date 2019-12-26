using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Results_2
{
    class Program
    {
        static void Main(string[] args)
        {
           

            string game1 = Console.ReadLine();
            string game2 = Console.ReadLine();
            string game3 = Console.ReadLine();
            int gameWon = 0;
            int gameLos = 0;
            int gameDrawn = 0;
            if (game1[0] < game1[2])
            {
                gameLos++;
            }
            else if (game1[0] > game1[2])
            {
                gameWon++;
            }
            else
            {
                gameDrawn++;
            }
            if (game2[0] < game2[2])
            {
                gameLos++;
            }
            else if (game2[0] > game2[2])
            {
                gameWon++;
            }
            else
            {
                gameDrawn++;
            }
            if (game3[0] < game3[2])
            {
                gameLos++;
            }
            else if (game3[0] > game3[2])
            {
                gameWon++;
            }
            else
            {
                gameDrawn++;
            }
            Console.WriteLine($"Team won {gameWon} games.");
            Console.WriteLine($"Team lost {gameLos} games.");
            Console.WriteLine($"Drawn games: {gameDrawn}");
        }
    }
}
