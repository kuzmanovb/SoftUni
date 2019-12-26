using System;
using System.Collections.Generic;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            var company = new SortedDictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArr = input.Split(" -> ");

                string nameCompany = inputArr[0];
                string carNumber = inputArr[1];

                if (!company.ContainsKey(nameCompany))
                {
                    company.Add(nameCompany, new List<string> {carNumber});
                }
                else if (!company[nameCompany].Contains(carNumber))
                {
                    company[nameCompany].Add(carNumber);
                }
               
                input = Console.ReadLine();
            }

            foreach (var item in company)
            {
                Console.WriteLine(item.Key);
                foreach (var number in item.Value)
                {
                    Console.WriteLine($"-- {number}");
                }
            }
            
        }
    }
}
