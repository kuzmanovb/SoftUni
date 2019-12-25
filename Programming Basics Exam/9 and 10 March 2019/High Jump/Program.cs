using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Вход
            //Входът е поредица от цели числа в интервала[100…300]:
            //•	На първия ред се прочита желаната от Тихомир Иванов височина в сантиметри
            //•	На всеки следващ ред до приключване на програмата се прочита височината от скока на Иванов
            //Изход
            //На конзолата трябва да се отпечата един ред:
            //•	Ако Тихомир не успее да преодолее желаната височина:
            //o   "Tihomir failed at {височина на летвата към момента на провала}cm after {брой скокове от началото на тренировката} jumps."
            //•	Ако Тихомир успее да преодолее височината:
            //o   "Tihomir succeeded, he jumped over {височина на прескочената последно летва}cm after {брой скокове за цялата тренировка} jumps."

            int jumpLevel = int.Parse(Console.ReadLine());
            int starLevel = jumpLevel - 30;
            int jumpNumber = 0;
            int jumpTry = 0;

            while (true)
            {
                if (jumpTry >= 3)
                {
                    Console.WriteLine($"Tihomir failed at {starLevel}cm after {jumpNumber} jumps.");
                    break;
                }
                else
                {

                    int jump = int.Parse(Console.ReadLine());

                    if (jump > starLevel && starLevel >= jumpLevel)
                    {
                        jumpNumber++;
                        Console.WriteLine($"Tihomir succeeded, he jumped over {starLevel}cm after {jumpNumber} jumps.");
                        break;
                    }

                    else if (jump > starLevel)

                    {
                        starLevel += 5;
                        jumpNumber++;
                        jumpTry = 0;
                    }
                    else if (jump <= starLevel)
                    {
                        jumpNumber++;
                        jumpTry++;
                    }

                }
            }

        }
    }
}
