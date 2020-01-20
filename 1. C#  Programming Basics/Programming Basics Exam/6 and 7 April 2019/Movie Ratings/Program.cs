using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Вход
            //От конзолата първо се чете един ред:
            //•	Брой филми, които си е набелязала Деси – цяло число в интервала[1…20]
            //За всеки филм се прочитат два отделни реда:
            //•	Име на филма – текст
            //•	Рейтинг на филма - реално число в интервала[1.00…10.00]
            //Изход
            //Отпечатват се три реда в следния формат:
            //•	"{име на филма с най-висок рейтинг} is with highest rating: {рейтинг на филма}"
            //•	"{име на филма с най-нисък рейтинг} is with lowest rating: {рейтинг на филма}"
            //•	"Average rating: {средният рейтинг на всички филми}"

            int movie = int.Parse(Console.ReadLine());
            string movieUp = null;
            double rangUp = 0;
            string movieDown = null;
            double rangDown = 11;
            double rangAll = 0;

            for (int i = 1; i <= movie; i++)
            {
                string name = Console.ReadLine();
                double rang = double.Parse(Console.ReadLine());
                rangAll += rang;
                if ( rang < rangDown)
                {
                    movieDown = name;
                    rangDown = rang;
                }
                if (rang > rangUp)
                {
                    movieUp = name;
                    rangUp = rang;
                }
                
            }
            double rangAverage = rangAll / movie;
           
            Console.WriteLine($"{movieUp} is with highest rating: {rangUp:f1}");
            Console.WriteLine($"{movieDown} is with lowest rating: {rangDown:f1}");
            Console.WriteLine($"Average rating: {rangAverage:f1}");
        }
    }
}
