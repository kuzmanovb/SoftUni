using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        public Trip()
        {
            this.UserTrips = new HashSet<UserTrip>();
            this.Id = Guid.NewGuid().ToString();
        }
        
        [Required]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }
        
        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [MaxLength(6)]
        public int Seats { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
