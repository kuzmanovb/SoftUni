using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());

            double allEvaluation = 0;
            int allProblems = 0;

            while (true)
            {
                double counter = 0;
                string problems = Console.ReadLine();
                if (problems == "Finish")
                {
                    break;
                }
                for (int i = 0; i < jury; i++)
                {
                    double evaluation = double.Parse(Console.ReadLine());
                    counter += evaluation;
                    allEvaluation += evaluation;

                }
                Console.WriteLine($"{problems} - {(counter / jury):f2}.");
                allProblems++;
            }

            Console.WriteLine($"Student's final assessment is {(allEvaluation / (allProblems * jury)):f2}.");
        }
    }
}
