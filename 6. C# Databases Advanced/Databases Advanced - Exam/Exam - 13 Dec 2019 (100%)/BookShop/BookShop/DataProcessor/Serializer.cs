namespace BookShop.DataProcessor
{
    using System;
    using System.Linq;
    using System.Globalization;

    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    using BookShop.XMLHelper;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var craziestAuthors = context.Authors
                                  .Select(a => new CraziesAuthorDTO
                                  {
                                      AuthorName = a.FirstName + " " + a.LastName,
                                      Books = a.AuthorsBooks.OrderByDescending(x => x.Book.Price)
                                      .Select(b => new CraziesAuthorBooksDTO
                                      {
                                          BookName = b.Book.Name,
                                          BookPrice = b.Book.Price.ToString("F2")
                                      })
                                      .ToList()
                                  })
                                  .ToList()
                                  .OrderByDescending(x => x.Books.Count())
                                  .ThenBy(a => a.AuthorName);


            var craziestAuthorsJSON = JsonConvert.SerializeObject(craziestAuthors, Formatting.Indented);

            return craziestAuthorsJSON;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var oldestBook = context.Books
                             .Where(b => b.PublishedOn < date && b.Genre == (Genre)3)
                             .Select(b => new OldestBooksDTO
                             {
                                 Name = b.Name,
                                 Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                                 Pages = b.Pages
                             })
                             .OrderByDescending(p => p.Pages)
                             .ThenByDescending(d => d.Date)
                             .Take(10)
                             .ToList();

            var oldestBookXML = XMLConverter.Serialize(oldestBook, "Books");

            return oldestBookXML;

        }
    }
}