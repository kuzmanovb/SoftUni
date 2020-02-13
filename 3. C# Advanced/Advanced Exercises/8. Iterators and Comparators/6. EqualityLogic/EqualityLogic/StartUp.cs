using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var collectionSorted = new SortedSet<Person>();
            var collectionHash = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var newPerson = new Person(name, age);

                collectionSorted.Add(newPerson);
                collectionHash.Add(newPerson);
            }

            Console.WriteLine(collectionSorted.Count);
            Console.WriteLine(collectionHash.Count);

        }
    }
}
