//Added by Irada to make the Bookings View display the CustomerID & Total price to customers. Do not Delete!

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExperts.Team1.WebApp.Models
{
    public class BookingsViewModel
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }

        [DisplayName("Itinerary No.")]
        public double? ItineraryNo { get; set; }
        public double? TravelerCount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Trip Starts")] 
        public DateTime? TripStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Trip Ends")] 
        public DateTime? TripEnd { get; set; }

        public string Destination { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? AgencyCommission { get; set; }
        [DisplayName("Total")]
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        public decimal? TotalPrice { get; set; }
        public string Description { get; set; }
    }
}
