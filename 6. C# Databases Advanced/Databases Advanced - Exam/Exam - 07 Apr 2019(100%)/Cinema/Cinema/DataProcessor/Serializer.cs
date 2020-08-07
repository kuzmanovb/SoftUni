namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using Data;
    using Cinema.XMLHelper;
    using Cinema.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {

            var topMovies = context.Movies
                           .Where(r => r.Rating >= rating && r.Projections.Any(t => t.Tickets.Count > 0))
                           .OrderByDescending(r => r.Rating)
                           .ThenByDescending(i => i.Projections.Sum(t => t.Tickets.Sum(p => p.Price)))
                           .Select(m => new
                           {
                               MovieName = m.Title,
                               Rating = m.Rating.ToString("F2"),
                               TotalIncomes = m.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                               Customers = m.Projections
                                           .SelectMany(t => t.Tickets)
                                           .Select(c => new
                                           {
                                               FirstName = c.Customer.FirstName,
                                               LastName = c.Customer.LastName,
                                               Balance = c.Customer.Balance.ToString("F2"),
                                           })
                                           .OrderByDescending(b => b.Balance)
                                           .ThenBy(f => f.FirstName)
                                           .ThenBy(l => l.LastName)
                                           .ToList()
                           })
                           .Take(10)
                           .ToList();

            var topMoviesToJSON = JsonConvert.SerializeObject(topMovies, Formatting.Indented);

            return topMoviesToJSON;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var topCustomers = context.Customers
                               .Where(c => c.Age >= age)
                               .OrderByDescending(s => s.Tickets.Sum(t => t.Price))
                               .Take(10)
                               .Select(c => new ExportTopCustomerDTO
                               {
                                   FirstName = c.FirstName,
                                   LastName = c.LastName,
                                   SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                                   SpentTime = TimeSpan.FromSeconds(c.Tickets.Sum(p => p.Projection.Movie.Duration.TotalSeconds)).ToString("hh\\:mm\\:ss")
                               })
                               .ToList();

            var topCustomersXML = XMLConverter.Serialize(topCustomers, "Customers");

            return topCustomersXML;
        }
    }
}