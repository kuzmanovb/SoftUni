using SharedTrip.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Service
{
    public interface ITripsService
    {
        string AddTrip(AddTripModel input);

        ICollection<TripViewModel> AllTrips();

        Trip GetTripById(string id);

        void AddUserToTrip(string tripId, string userId);

        bool CheckUserTripExist(string tripId, string userId);

    }
}
