using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArr = input.Split();

                Person infoForPerson = new Person();

                infoForPerson.Name = inputArr[0];
                infoForPerson.ID = inputArr[1];
                infoForPerson.Age = int.Parse(inputArr[2]);

                allPeople.Add(infoForPerson);
                
                input = Console.ReadLine();
            }

            allPeople = allPeople.OrderBy(x => x.Age).ToList();

            foreach (var item in allPeople)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }

            
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }


    }
}
