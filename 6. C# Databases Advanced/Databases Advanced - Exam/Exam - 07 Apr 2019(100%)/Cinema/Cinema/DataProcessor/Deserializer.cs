namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using Cinema.XMLHelper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesFromJSON = JsonConvert.DeserializeObject<List<ImportMovieDTO>>(jsonString);

            var sb = new StringBuilder();
            var moviesForImport = new List<Movie>();
            var titles = new List<string>();

            foreach (var m in moviesFromJSON)
            {
                if (!IsValid(m))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                if (titles.Contains(m.Title))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                titles.Add(m.Title);

                var newMovie = new Movie
                {
                    Title = m.Title,
                    Genre = m.Genre,
                    Duration = m.Duration,
                    Rating = m.Rating,
                    Director = m.Director
                };

                moviesForImport.Add(newMovie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, m.Title, m.Genre, m.Rating.ToString("F2")));
            }


            context.Movies.AddRange(moviesForImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallSeatFromJSON = JsonConvert.DeserializeObject<List<ImportHallSeatDTO>>(jsonString);

            var sb = new StringBuilder();
            var hallForImport = new List<Hall>();
            var seatForImport = new List<Seat>();

            foreach (var hs in hallSeatFromJSON)
            {

                if (!IsValid(hs))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var newHall = new Hall
                {
                    Name = hs.Name,
                    Is4Dx = hs.Is4Dx,
                    Is3D = hs.Is3D,
                };

                hallForImport.Add(newHall);

                for (int i = 0; i < hs.Seats; i++)
                {
                    var newSeat = new Seat
                    {
                        Hall = newHall
                    };

                    seatForImport.Add(newSeat);
                }

                string projectType;

                if (hs.Is3D == true && hs.Is4Dx == true)
                {
                    projectType = "4Dx/3D";
                }
                else if (hs.Is3D == true)
                {
                    projectType = "3D";
                }
                else if (hs.Is4Dx == true)
                {
                    projectType = "4Dx";
                }
                else
                {
                    projectType = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hs.Name, projectType, hs.Seats));
            }

            context.Halls.AddRange(hallForImport);
            context.Seats.AddRange(seatForImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var projectionsFromXML = XMLConverter.Deserializer<ImportProjectionDTO>(xmlString, "Projections");

            var sb = new StringBuilder();
            var projectionsForImport = new List<Projection>();

            var moviesId = context.Movies.Select(m => m.Id).ToList();
            var hallsId = context.Halls.Select(h => h.Id).ToList();


            foreach (var p in projectionsFromXML)
            {
                if (!IsValid(p))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var checkHallId = hallsId.Contains(p.HallId);
                var checkMovieId = moviesId.Contains(p.MovieId);

                if (!checkHallId || !checkMovieId)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var newProjection = new Projection
                {
                    MovieId = p.MovieId,
                    HallId = p.HallId,
                    DateTime = DateTime.ParseExact(p.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projectionsForImport.Add(newProjection);

                var movieTitle = context.Movies.Where(m => m.Id == p.MovieId).Select(t => t.Title).FirstOrDefault();
                var projectionDate = newProjection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                sb.AppendLine(string.Format(SuccessfulImportProjection, movieTitle, projectionDate));

            }

            context.Projections.AddRange(projectionsForImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var customersTicketsFromXML = XMLConverter.Deserializer<ImportCustomersTicketsDTO>(xmlString, "Customers");

            var sb = new StringBuilder();
            var customerForImport = new List<Customer>();
            var ticketForImport = new List<Ticket>();
            var projectionsId = context.Projections.Select(p => p.Id).ToList();

            foreach (var ct in customersTicketsFromXML)
            {
                if (!IsValid(ct))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var newCustomer = new Customer
                {
                    FirstName = ct.FirstName,
                    LastName = ct.LastName,
                    Age = ct.Age,
                    Balance = ct.Balance
                };

                var checkTicket = true;
                var curentTickets = new List<Ticket>();

                foreach (var t in ct.Tickets)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        checkTicket = false;
                        break;
                    }

                    if (!projectionsId.Contains(t.ProjectionId))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        checkTicket = false;
                        break;
                    }

                    var newTicket = new Ticket
                    {
                        ProjectionId = t.ProjectionId,
                        Customer = newCustomer,
                        Price = t.Price
                    };

                    curentTickets.Add(newTicket);
                }

                if (checkTicket)
                {
                    customerForImport.Add(newCustomer);
                    ticketForImport.AddRange(curentTickets);
                    sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, ct.FirstName, ct.LastName, curentTickets.Count));
                }
            }

            context.Customers.AddRange(customerForImport);
            context.Tickets.AddRange(ticketForImport);
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