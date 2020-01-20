using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            var allLenguage = new SortedDictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] inputArr = input.Split('-');

                string nameStudent = inputArr[0];
                string lenguageStudent = inputArr[1];

                if (lenguageStudent == "banned")
                {

                }
                else if (!allLenguage.ContainsKey(lenguageStudent))
                {
                    allLenguage.Add(lenguageStudent, 1);
                }
                else
                {
                    allLenguage[lenguageStudent]++;
                }


                if (lenguageStudent != "banned")
                {
                    int pointStudent = int.Parse(inputArr[2]);

                    bool check = true; ;

                    foreach (var item in students)
                    {
                        if (item.Name.Contains(nameStudent) && item.Lenguage.Contains(lenguageStudent))
                        {
                            if (item.Points < pointStudent)
                            {
                                item.Points = pointStudent;
                            }
                            check = false; ;
                            break;
                        }
                    }

                    if (check)
                    {
                        var newStudents = new Student();
                        newStudents.Name = nameStudent;
                        newStudents.Lenguage = lenguageStudent;
                        newStudents.Points = pointStudent;
                        students.Add(newStudents);
                    }
                }

                else
                {
                    foreach (var item in students)
                    {
                        if (item.Name == nameStudent)
                        {
                            item.Name = null;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            students = students.OrderByDescending(x => x.Points).ThenBy(a => a.Name).ToList();
            var allLenguage2 = allLenguage.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var item in students)
            {
                if (item.Name != null)
                {
                    Console.WriteLine(item.Name + " | " + item.Points);
                }

            }

            Console.WriteLine("Submissions:");

            foreach (var item in allLenguage2)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string Lenguage { get; set; }
        public int Points { get; set; }

    }
}
