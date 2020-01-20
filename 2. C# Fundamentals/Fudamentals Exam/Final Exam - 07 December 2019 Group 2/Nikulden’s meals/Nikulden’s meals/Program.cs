using System;
using System.Collections.Generic;
using System.Linq;

namespace Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            var guest = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            int countUnlike = 0;

            while (command != "Stop")
            {

                string[] commandArr = command.Split("-");

                string likeOrUnlike = commandArr[0];
                string curentGuest = commandArr[1];
                string meal = commandArr[2];

                if (likeOrUnlike == "Like")
                {
                    if (!guest.ContainsKey(curentGuest))
                    {
                        guest.Add(curentGuest, new List<string>());
                    }
                    if (!guest[curentGuest].Contains(meal))
                    {
                        guest[curentGuest].Add(meal);
                    }
                }
                else if (likeOrUnlike == "Unlike")
                {
                    if (!guest.ContainsKey(curentGuest))
                    {
                        Console.WriteLine($"{curentGuest} is not at the party.");
                    }
                    else if (!guest[curentGuest].Contains(meal))
                    {
                        Console.WriteLine($"{curentGuest} doesn't have the {meal} in his/her collection.");
                    }
                    else if (guest[curentGuest].Contains(meal))
                    {
                        guest[curentGuest].Remove(meal);
                        Console.WriteLine($"{curentGuest} doesn't like the {meal}.");
                        countUnlike++;
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var item in guest.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                string meals = string.Join(", ", item.Value);

                Console.WriteLine($"{item.Key}: {meals}");

            }

            Console.WriteLine($"Unliked meals: {countUnlike}");
        }
    }
}
