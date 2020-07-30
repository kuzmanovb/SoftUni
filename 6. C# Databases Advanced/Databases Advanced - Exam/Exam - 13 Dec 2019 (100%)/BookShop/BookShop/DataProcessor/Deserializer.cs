namespace BookShop.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Newtonsoft.Json;

    using Data;
    using BookShop.XMLHelper;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var booksXML = XMLConverter.Deserializer<BookDTO>(xmlString, "Books");

            var sb = new StringBuilder();
            var booksForAdd = new List<Book>();

            foreach (var book in booksXML)
            {

                if (!IsValid(book))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var newBook = new Book
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = DateTime.ParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                booksForAdd.Add(newBook);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));


            }

            context.Books.AddRange(booksForAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsJSON = JsonConvert.DeserializeObject<List<AuthorDTO>>(jsonString);

            var sb = new StringBuilder();
            var authorsForAdd = new List<Author>();
            var authorsBooksForAdd = new List<AuthorBook>();
            var idBooksInData = context.Books.Select(b => b.Id).ToList();

            foreach (var authorJson in authorsJSON)
            {
                var emails = authorsForAdd.Select(a => a.Email).ToList();

                if (!IsValid(authorJson))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                if (emails.Contains(authorJson.Email))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var curentBooksId = new List<int>();

                foreach (var bookId in authorJson.BooksId)
                {
                    if (bookId.Id == null)
                    {
                        continue;
                    }
                    if (!idBooksInData.Contains((int)bookId.Id))
                    {
                        continue;
                    }

                    curentBooksId.Add((int)bookId.Id);
                }

                if (curentBooksId.Count == 0)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var newAuthor = new Author
                {
                    FirstName = authorJson.FirstName,
                    LastName = authorJson.LastName,
                    Phone = authorJson.Phone,
                    Email = authorJson.Email
                };

                authorsForAdd.Add(newAuthor);

                foreach (var curentBookId in curentBooksId)
                {
                    var newAuthorBook = new AuthorBook
                    {
                        Author = newAuthor,
                        BookId = (int)curentBookId
                    };

                    authorsBooksForAdd.Add(newAuthorBook);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, authorJson.FirstName + " " + authorJson.LastName, curentBooksId.Count));

            }

            context.Authors.AddRange(authorsForAdd);
            context.AuthorsBooks.AddRange(authorsBooksForAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}