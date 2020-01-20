using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSite = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSite; i++)
            {

                if (salary <= 0)
                {
                    continue;
                }
                string websiteName = Console.ReadLine();

                if (websiteName == "Facebook")
                {
                    salary -= 150;
                }
                else if (websiteName == "Instagram")
                {
                    salary -= 100;
                }
                else if (websiteName == "Reddit")
                {
                    salary -= 50;
                }

            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");

            }
            else
            {
                Console.WriteLine($"{salary}");

            }

        }
    }
}
