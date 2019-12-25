using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {

            //            Има три варианта за завършване на турнир:
            //	W - ако е победител получава 2000 точки
            //	F - ако е финалист получава 1200 точки
            //	SF - ако е полуфиналист получава 720 точки
            //Напишете програма, която изчислява колко ще са точките на Григор след изиграване на всички турнири, като знаете с колко точки стартира сезона.Също изчислете колко точки средно печели от всички изиграни турнири и колко процента от турнирите е спечелил.
            //Вход
            //От конзолата първо се четат два реда:
            //•	Брой турнири, в които е участвал – цяло число в интервала[1…20] 
            //•	Начален брой точки в ранглистата - цяло число в интервала[1...4000]
            //За всеки турнир се прочита отделен ред:
            //•	Достигнат етап от турнира – текст – "W", "F" или "SF"
            //Изход
            //Отпечатват се три реда в следния формат:
            //•	"Final points: {брой точки след изиграните турнири}"
            //•	"Average points: {средно колко точки печели за турнир}"
            //•	"{процент спечелени турнири}%"
            //Средните точки да бъдат закръглени към най - близкото цяло число надолу, а процентът да се форматира до втората цифра след десетичния знак.

            int turnir = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            double allPointTornirs = 0;
            double turnirWiner = 0;
            for (int i = 0; i < turnir; i++)
            {
                string pointTurnir = Console.ReadLine();
                if (pointTurnir == "W")
                {
                    allPointTornirs += 2000;
                    turnirWiner++;
                }
                else if (pointTurnir == "F")
                {
                    allPointTornirs += 1200;
                }
                else if (pointTurnir == "SF")
                {
                    allPointTornirs += 720;
                }
            }
            double allPoint = allPointTornirs + points;
            Console.WriteLine($"Final points: {allPoint}");
            Console.WriteLine($"Average points: {Math.Floor(allPointTornirs / turnir)}");
            Console.WriteLine($"{(turnirWiner/turnir)* 100:f2}%");
        }
    }
}
