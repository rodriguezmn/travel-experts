using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExperts.Team1.WebApp.Models
{
    public class BookingsModel
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        [DisplayName("Trip Starts")] public DateTime? TripStart { get; set; }

        [DisplayName("Trip Ends")] public DateTime? TripEnd { get; set; }

        public string Destination { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? AgencyCommission { get; set; }
        public string Description { get; set; }
    }
}
