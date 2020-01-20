using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Вход
            //Първоначално се четат два реда:
            //•	Име на първия играч -текст
            //•	Име на втория играч -текст
            //След това, до получаване на команда "End of game", се четат многократно по два реда:
            //1.Карта, която дава първият играч-цяло число в интервала[2…9]
            //2.Карта, която дава вторият играч -цяло число в интервала[2…9]
            //При еднакви карти на двамата играчи се прочитат нови два реда(карта, която дава първият и карта, която дава вторият.)
            //Изход
            //При случая, в който има "Number wars ", да се отпечата:
            //•	"Number wars!"
            //•	"{име на победителя} is winner with {брой натрупани точки} points"
            //При команда "End of game" да се отпечатат два реда:
            //•	"{име на първия играч} has {брой натрупани точки за първия играч} points"
            //•	"{име на втория играч} has {брой натрупани точки за втория играч} points"

            string gamer1 = Console.ReadLine();
            string gamer2 = Console.ReadLine();
            int gamer1Point = 0;
            int gamer2Point = 0;

            while (true)
            {
               
                    string imput1 = Console.ReadLine();
                    if (imput1 == "End of game")
                    {
                        Console.WriteLine($"{gamer1} has {gamer1Point} points");
                        Console.WriteLine($"{gamer2} has {gamer2Point} points");
                        break;
                    }
                    string imput2 = Console.ReadLine();

                    int kart1 = int.Parse(imput1);
                    int kart2 = int.Parse(imput2);

                    if (kart1 > kart2)
                    {
                        gamer1Point += kart1 - kart2;
                    }
                    else if (kart1 < kart2)
                    {
                        gamer2Point += kart2 - kart1;

                    }
                    else
                    {
                        int kart11 = int.Parse(Console.ReadLine());
                        int kart22 = int.Parse(Console.ReadLine());
                        if (kart11 > kart22)
                        {
                            Console.WriteLine("Number wars!");
                            Console.WriteLine($"{gamer1} is winner with {gamer1Point} points");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Number wars!");
                            Console.WriteLine($"{gamer2} is winner with {gamer2Point} points");
                            break;
                        }
                    }
                

            }

        }
    }
}

