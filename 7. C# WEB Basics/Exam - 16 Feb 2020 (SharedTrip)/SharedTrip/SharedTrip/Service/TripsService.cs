using SharedTrip.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Service
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string AddTrip(AddTripModel input)
        {
            var newTrip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", null),
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description
            };

            this.db.Trips.Add(newTrip);
            this.db.SaveChanges();

            return newTrip.Id;

        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var newUserTrips = new UserTrip { TripId = tripId, UserId = userId };

            var curentTrip = this.db.Trips.FirstOrDefault(t => t.Id == tripId);

            curentTrip.Seats -= 1;

            this.db.Trips.Update(curentTrip);

            this.db.UserTrips.Add(newUserTrips);
            this.db.SaveChanges();

        }

        public ICollection<TripViewModel> AllTrips()
        {
            var allTrips = this.db.Trips
                .Select(t => new TripViewModel 
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    ImagePath = t.ImagePath,
                    Seats = t.Seats,
                    Description = t.Description
                })
                .ToArray();

            return allTrips;
        }

        public Trip GetTripById(string id)
        {
            var curentTrip = this.db.Trips.FirstOrDefault(t => t.Id == id);

            return curentTrip;
        }

        public bool CheckUserTripExist(string tripId, string userId)
        {

            var check = this.db.UserTrips.FirstOrDefault(u => u.UserId == userId && u.TripId == tripId);

            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
