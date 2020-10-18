using SharedTrip.Models;
using SharedTrip.Service;
using SharedTrip.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add (AddTripModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("The seats must be between 2 and 6");
            }

            if (input.Description.Length > 80)
            {
                return this.Error("The description must be up to 80 characters long");
            }

            this.tripsService.AddTrip(input);

            return this.Redirect("/Trips/All");
        }



        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var allTrips = this.tripsService.AllTrips();

            return this.View(allTrips);
        }

        public HttpResponse Details(string tripId)
        {

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var curentTrip = this.tripsService.GetTripById(tripId);

            return this.View(curentTrip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.User;

            if (this.tripsService.CheckUserTripExist(tripId, userId))
            {
                return this.Error("This trip has already been added");
            }


            this.tripsService.AddUserToTrip(tripId, userId);

            var curentTrip = this.tripsService.GetTripById(tripId);

            return this.View(curentTrip, "Details");

        }


    }
}
