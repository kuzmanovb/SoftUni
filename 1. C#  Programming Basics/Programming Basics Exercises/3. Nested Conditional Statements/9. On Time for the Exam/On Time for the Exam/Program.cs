using System;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinuts = int.Parse(Console.ReadLine());
            int arrivHours = int.Parse(Console.ReadLine());
            int arrivMinuts = int.Parse(Console.ReadLine());

            int examInMinutes = (examHours * 60) + examMinuts;
            int arrivInMinuts = (arrivHours * 60) + arrivMinuts;


            if (examInMinutes < arrivInMinuts)
            {
                int lateMinuts = arrivInMinuts - examInMinutes;
                if (lateMinuts < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{lateMinuts} minutes after the start");
                }
                else
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{lateMinuts / 60}:{lateMinuts % 60:d2} hours after the start");
                }

            }
            else if (examInMinutes == arrivInMinuts || examInMinutes - arrivInMinuts <= 30)
            {

                if (examInMinutes == arrivInMinuts)
                {
                    Console.WriteLine("On time");
                }
                else
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{examInMinutes - arrivInMinuts} minutes before the start");
                }

            }
            else if (examInMinutes - arrivInMinuts > 30)
            {
                int earlyMinuts = examInMinutes - arrivInMinuts;
                if (earlyMinuts < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{earlyMinuts} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{earlyMinuts / 60}:{earlyMinuts % 60:d2} hours before the start");
                }

            }
        }
    }
}
