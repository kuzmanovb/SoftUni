using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorProblemMax = int.Parse(Console.ReadLine());

            int poorProblem = 0;
            double successProblem = 0;
            double allProblem = 0;
            string lastProblemName = "";


            while (poorProblemMax > poorProblem)
            {
                string nameProblem = Console.ReadLine();

                if (nameProblem == "Enough")
                {
                    Console.WriteLine($"Average score: {successProblem / allProblem:f2}");
                    Console.WriteLine($"Number of problems: {allProblem}");
                    Console.WriteLine($"Last problem: {lastProblemName}");
                    return;
                }
                lastProblemName = nameProblem;
                int averag = int.Parse(Console.ReadLine());

                if (averag <= 4)
                {
                    poorProblem++;
                }
                successProblem += averag;
                allProblem++;

            }
            Console.WriteLine($"You need a break, {poorProblem} poor grades.");
        }
    }
}
