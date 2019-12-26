using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsNumber = int.Parse(Console.ReadLine());

            var allStudents = new List<Students>();

            for (int i = 0; i < studentsNumber; i++)
            {
                string[] student = Console.ReadLine().Split();

                string firstName = student[0];
                string secondName = student[1];
                double grade = double.Parse(student[2]);

                var name = new Students(firstName, secondName, grade);

                allStudents.Add(name);
            }

            allStudents = allStudents.OrderBy(x => x.Grade).ToList();
            allStudents.Reverse();

            foreach (var item in allStudents)
            {
                Console.WriteLine($"{item.FirstName} {item.SecondName}: {item.Grade:f2}");
            }

        }
    }

    class Students
    {
        public Students(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;

        }

        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public double Grade { set; get; }


    }       

}
