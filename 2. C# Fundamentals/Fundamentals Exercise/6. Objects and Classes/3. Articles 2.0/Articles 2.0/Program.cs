using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberForArticles = int.Parse(Console.ReadLine());

            List<Artic> articleNames = new List<Artic>();


            for (int i = 0; i < numberForArticles; i++)
            {

                string[] article = Console.ReadLine().Split(", ");


                var name = new Artic();

                name.Title = article[0];
                name.Content = article[1];
                name.Author = article[2];

                articleNames.Add(name);
            }

            string orderCriteria = Console.ReadLine();

            if (orderCriteria == "title")
            {
                articleNames = articleNames.OrderBy(x => x.Title).ToList();
            }
            else if (orderCriteria == "content")
            {
                articleNames = articleNames.OrderBy(x => x.Content).ToList(); ;
            }
            else if (orderCriteria == "author")
            {
                articleNames = articleNames.OrderBy(x => x.Author).ToList();
            }

            foreach (var item in articleNames)
            {
                Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
            }

        }
    }
    class Artic
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
