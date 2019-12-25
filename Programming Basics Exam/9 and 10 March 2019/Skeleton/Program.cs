using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Трябва да се има предвид, че поради наклона на улея, на всеки 120 метра неговото време намаля с 2.5 секунди.
            //Вход
            //От конзолата се четат 4 реда:
            //Ред 1.Минути на контролата – цяло число в интервала[0…59]
            //Ред 2.Секунди на контролата – цяло число в интервала[0…59]
            //Ред 3.Дължината на улея в метри – реално число в интервала[0.00…50000]
            //Ред 4.Секунди за изминаване на 100 метра – цяло число в интервала[0…1000]
            //Изход
            //На конзолата трябва да се отпечата на един или два реда:
            //•	Ако времето на Марин е по-малко или равно на контролата:
            //o   "Marin Bangiev won an Olympic quota!"
            //o   "His time is {времето на Марин в секунди}."
            //•	Ако времето на Марин е повече от това на контролата:
            //o    "No, Marin failed! He was {недостигащи секунди} second slower."
            //Резултатът трябва да е форматиран до третия знак след десетичния знак.

            int checkMinuts = int.Parse(Console.ReadLine());
            int checkSeconds = int.Parse(Console.ReadLine());
            double longGroove = double.Parse(Console.ReadLine());
            int seconds100 = int.Parse(Console.ReadLine());

            double checkSecondsAll = checkMinuts * 60.0 + checkSeconds;

            double checkDown = (longGroove / 120.0);
            double checkPlayer = (longGroove / 100) * seconds100 - (checkDown * 2.5);

            if (checkPlayer <= checkSecondsAll)
            {

                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {checkPlayer:f3}.");

            }
            else
            {

                Console.WriteLine($"No, Marin failed! He was {checkPlayer - checkSecondsAll:f3} second slower.");
            }



            //Изчисляване на контролата в секунди: 2 * 60 + 12 => 132 секунди
            //Изчисляване, колко пъти времето ще намалее: 1200 / 120 = 10
            //Общо намалено време: 10 * 2.5 = 25 секунди
            //Времето на Марин: (1200 / 100) * 10 – 25 = 95 секунди
            //Контролно време: 132 сек., времето на Марин - 95 сек.
            //95 <= 132->Марин взима квота.

        }

    }
}
