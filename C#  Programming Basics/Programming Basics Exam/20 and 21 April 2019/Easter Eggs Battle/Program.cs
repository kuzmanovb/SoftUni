using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsPlayer1 = int.Parse(Console.ReadLine());
            int eggsPlayer2 = int.Parse(Console.ReadLine());

            while (true)
            {
                if (eggsPlayer1 ==0 )
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {eggsPlayer2} eggs left.");
                    break;
                }
                else if (eggsPlayer2 == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {eggsPlayer1} eggs left.");
                    break;
                }
                string playerWin = Console.ReadLine();
                if (playerWin == "End of battle")
                {
                    Console.WriteLine($"Player one has {eggsPlayer1} eggs left.");
                    Console.WriteLine($"Player two has {eggsPlayer2} eggs left.");
                    break;
                }
                else if (playerWin == "one")
                {
                    eggsPlayer2--;
                }
                else if (playerWin == "two")
                {
                    eggsPlayer1--;
                }
            }


        }
    }
}
