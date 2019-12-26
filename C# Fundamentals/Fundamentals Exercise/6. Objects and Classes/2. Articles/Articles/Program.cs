using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int numberCommands = int.Parse(Console.ReadLine());
            var articlesNew = new Article(input[0], input[1], input[2]);

            for (int i = 0; i < numberCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    articlesNew.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    articlesNew.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    articlesNew.Rename(command[1]);
                }
            }

            Console.WriteLine($"{articlesNew.Title} - {articlesNew.Content}: {articlesNew.Author}");
        }
    }
}


