namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            ////-------------------------------------------------------------------------
            //// 2. Age Restriction
            //var input1 = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, input1);
            //Console.WriteLine(result);

            ////-------------------------------------------------------------------------
            //// 3. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            ////-------------------------------------------------------------------------
            //// 4. Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            ////-------------------------------------------------------------------------
            //// 5. Not Released In
            //var input4 = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, input4));

            ////-------------------------------------------------------------------------
            //// 6. Book Titles by Category
            //var input5 = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input5));

            ////-------------------------------------------------------------------------
            //// 7. Released Before Date
            //var input6 = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, input6));

            ////-------------------------------------------------------------------------
            //// 8. Author Search
            //var input7 = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input7));

            ////-------------------------------------------------------------------------
            //// 9. Book Search
            //var input8 = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input8));

            ////-------------------------------------------------------------------------
            //// 10. Book Search by Author
            //var input9 = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input9));

            ////-------------------------------------------------------------------------
            //// 11. Count Books
            //var input10 = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, input10));

            ////-------------------------------------------------------------------------
            //// 12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            ////-------------------------------------------------------------------------
            //// 13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(db));

            ////-------------------------------------------------------------------------
            //// 14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(db));

            ////-------------------------------------------------------------------------
            //// 15. Increase Prices
            //IncreasePrices(db);

            ////-------------------------------------------------------------------------
            //// 16. Remove Books
            //Console.WriteLine(RemoveBooks(db));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            var bookTitles = context.Books
                                    .ToList()
                                    .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                                    .Select(b => new { b.Title })
                                    .OrderBy(b => b.Title)
                                    .ToList();

            var sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                                     .ToList()
                                     .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                                     .OrderBy(b => b.BookId)
                                     .Select(b => new { b.Title })
                                     .ToList();

            var sb = new StringBuilder();

            foreach (var t in goldenBooks)
            {
                sb.AppendLine(t.Title);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookPrice = context.Books
                                   .Where(b => b.Price > 40)
                                   .Select(b => new { b.Price, b.Title })
                                   .OrderByDescending(b => b.Price)
                                   .ToList();

            var sb = new StringBuilder();

            foreach (var t in bookPrice)
            {
                sb.AppendLine($"{t.Title} - ${t.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var book = context.Books
                              .Where(b => b.ReleaseDate.Value.Year != year)
                              .OrderBy(b => b.BookId)
                              .Select(b => new { b.Title })
                              .ToList();

            var sb = new StringBuilder();

            foreach (var t in book)
            {
                sb.AppendLine(t.Title);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var book = new List<string>();

            foreach (var category in categories)
            {
                var curentBook = context.Books
                                  .Where(b => b.BookCategories.Any(c => c.Category.Name.ToLower() == category.ToLower()))
                                  .Select(b => new { b.Title })
                                  .ToList();

                foreach (var cb in curentBook)
                {
                    book.Add(cb.Title);
                }
            }

            var sb = new StringBuilder();

            foreach (var t in book.OrderBy(t => t))
            {
                sb.AppendLine(t);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var books = context.Books
                               .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentCulture))
                               .Select(b => new { b.Title, b.EditionType, b.Price, b.ReleaseDate })
                               .OrderByDescending(b => b.ReleaseDate)
                               .ToList();

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                                 .Where(a => a.FirstName.EndsWith(input))
                                 .Select(a => new { name = a.FirstName + " " + a.LastName })
                                 .OrderBy(a => a.name)
                                 .ToList();

            var sb = new StringBuilder();

            foreach (var a in authors)
            {
                sb.AppendLine(a.name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                               .Select(b => new { b.Title })
                               .OrderBy(t => t.Title)
                               .ToList();

            var sb = new StringBuilder();

            foreach (var t in books)
            {
                sb.AppendLine(t.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksAuthors = context.Books
                                      .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                                      .Select(b => new { b.Title, name = b.Author.FirstName + " " + b.Author.LastName, b.BookId })
                                      .OrderBy(b => b.BookId)
                                      .ToList();

            var sb = new StringBuilder();

            foreach (var t in booksAuthors)
            {
                sb.AppendLine($"{t.Title} ({t.name})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countBooks = context.Books
                                    .ToList()
                                    .Where(b => b.Title.Count() > lengthCheck)
                                    .ToList();

            return countBooks.Count();
        }


        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Authors
                .Select(a => new
                {
                    name = a.FirstName + " " + a.LastName,
                    count = a.Books.Select(b => b.Copies).Sum()

                })
                .OrderByDescending(b => b.count);


            var sb = new StringBuilder();

            foreach (var i in bookCopies)
            {
                sb.AppendLine($"{i.name} - {i.count}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitCategory = context.Categories
                                        .Select(c => new
                                        {
                                            c.Name,
                                            Profit = c.CategoryBooks.Select(b => b.Book.Copies * b.Book.Price).Sum()
                                        })
                                        .OrderByDescending(p => p.Profit)
                                        .ThenBy(n => n.Name)
                                        .ToList();

            var sb = new StringBuilder();

            foreach (var i in profitCategory)
            {
                sb.AppendLine($"{i.Name} ${i.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                               .Select(c => new
                               {
                                   c.Name,
                                   booksNameYear = c.CategoryBooks.Select(b => new
                                   {
                                       b.Book.Title,
                                       b.Book.ReleaseDate
                                   }).OrderByDescending(y => y.ReleaseDate).Take(3)
                               })
                               .OrderBy(o => o.Name)
                               .ToList();

            var sb = new StringBuilder();

            foreach (var i in books)
            {
                sb.AppendLine($"--{i.Name}");

                foreach (var b in i.booksNameYear)
                {
                    sb.AppendLine($"{b.Title } ({b.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {

            var prices = context.Books.Where(r => r.ReleaseDate.Value.Year < 2010);

            foreach (var p in prices)
            {
                p.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var entityForRemove = context.Books.Where(b => b.Copies < 4200);
            var result = entityForRemove.Count();

            context.Books.RemoveRange(entityForRemove);

            context.SaveChanges();


            return result;
        }
    }
}
