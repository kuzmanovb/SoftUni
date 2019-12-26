using System;

namespace Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random newNumber = new Random();
            for (int i = 0; i < number; i++)
            {
                string phrasRandom = phrases[newNumber.Next(0, 6)];
                string eventRandom = events[newNumber.Next(0, 6)];
                string authorRandom = authors[newNumber.Next(0, 8)];
                string cityRandom = cities[newNumber.Next(0, 5)];

                Console.WriteLine($"{phrasRandom}{eventRandom}{authorRandom} - {cityRandom}");
            }
        }
    }
}
