using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Вход
            // Входът е поредица от цели числа и текст:
            //•	На първия ред до получаване на командата "Finish" - име на филма – текст
            //•	На втори ред – свободните места в салона за всяка прожекция – цяло число[1 … 100]
            //•	За всеки филм, се чете по един ред до изчерпване на свободните места в залата или до получаване на командата "End":
            //o Типа на закупения билет - текст("student", "standard", "kid")
            //Изход
            //На конзолата трябва да се печатат следните редове:
            //•	След всеки филм да се отпечата, колко процента от кино залата е пълна
            //"{името на филма} - {процент запълненост на залата}% full."
            //•	При получаване на командата "Finish" да се отпечатат четири реда:
            //            o   "Total tickets: {общият брой закупени билети за всички филми}"
            //o   "{процент на студентските билети}% student tickets."
            //o   "{процент на стандартните билети}% standard tickets."
            //o   "{процент на детските билети}% kids tickets."

            int studentAll = 0;
            int standardAll = 0;
            int kidAll = 0;

            while (true)
            {
                string nameMuve = Console.ReadLine();
                double clozet = 0;
                int allTicket = studentAll + standardAll + kidAll;
                int seatDuble = 0;

                if (nameMuve != "Finish")
                {
                int freeSeats = int.Parse(Console.ReadLine());
                    seatDuble = freeSeats;

                    for (int i = 0; i < freeSeats; i++)
                    {
                        string ticket = Console.ReadLine();
                        if (ticket == "student")
                        {
                            studentAll++;
                            clozet++;
                        }
                        else if (ticket == "standard")
                        {
                            standardAll++;
                            clozet++;
                        }
                        else if (ticket == "kid")
                        {
                            kidAll++;
                            clozet++;
                        }
                        else if (ticket == "End")
                        {
                            break;
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"Total tickets: {allTicket}");
                    Console.WriteLine($"{(studentAll*1.0 / allTicket) * 100:f2}% student tickets.");
                    Console.WriteLine($"{(standardAll*1.0 / allTicket) * 100:f2}% standard tickets.");
                    Console.WriteLine($"{ (kidAll*1.0 / allTicket) * 100:f2}% kids tickets.");
                    break;
                    
                }
                double hallProcent = (clozet / seatDuble) * 100;
                Console.WriteLine($"{nameMuve} - {hallProcent:f2}% full.");
                

            }

        }
    }
}
