using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var collection = new List<Person>();

            var input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                var name = input[0];
                var age = int.Parse(input[1]);
                var town = input[2];

                collection.Add(new Person(name, age, town));

                input = Console.ReadLine().Split();
            }

            var personForMatch = collection[int.Parse(Console.ReadLine()) - 1];
            var matches = 0;

            foreach (var item in collection)
            {
                if (personForMatch.CompareTo(item) == 0)
                {
                    matches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {collection.Count - matches} {collection.Count}");
            }






        }
    }
}
