using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < inputNumber; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double> { grade });
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            students = students.OrderByDescending(x => x.Value.Average()).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in students)
            {
                if (item.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }

        }
    }
}
