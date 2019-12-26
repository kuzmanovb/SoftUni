using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Вход
            //От конзолата се четат поредица от турнири до получаване на командата "End of tournaments":
            //•	Име на турнира – текст
            //•	За всеки турнир n на брой мача – цяло число в интервала[1…15]
            //•	За всеки мач се четат по два реда:
            //o Точки, вкарани от отбора на Деси – цяло число в интервала от[0…150]
            //o Точки, вкарани от противниковия отбор – цяло число в интервала от[0…150]
            //Изход
            //На конзолата да се отпечатат следните редове:
            //•	След всеки мач да се отпечатва дали отборът на Деси е спечелил или загубил и съответно с каква разлика.
            //•	При получаване на команда "End of tournaments" да се отпечатат два реда:
            //            o   { процент спечелени мачове от всички турнири}% matches win
            //             o   { процент загубени мачове от всички турнири}% matches lost
            //              Всички проценти трябва да са форматирани до втората цифра след десетичния знак.

                    double winGame = 0;
                    double lostGame = 0;
                    double machesAll = 0;

            while (true)
            {
                string nameGame = Console.ReadLine();
                if (nameGame == "End of tournaments")
                {
                    break;
                }
                else
                {
                    int numberGame = int.Parse(Console.ReadLine());


                    for (int i = 1; i <= numberGame; i++)
                    {
                         machesAll++;
                        int pointDesi = int.Parse(Console.ReadLine());
                        int pointPesho = int.Parse(Console.ReadLine());
                        int point = 0;
                        string desiWiner = null;
                        if (pointDesi > pointPesho)
                        {
                            point = pointDesi - pointPesho;
                            desiWiner = "win";
                            winGame++;
                        }
                        else
                        {
                            point = pointPesho - pointDesi;
                            desiWiner = "lost";
                            lostGame++;
                        }
                        Console.WriteLine($"Game {i} of tournament {nameGame}: {desiWiner} with {point} points.");

                    }

                }

            }
            Console.WriteLine($"{winGame / machesAll * 100:f2}% matches win");
            Console.WriteLine($"{lostGame / machesAll * 100:f2}% matches lost");
        }
    }
}
