using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Bookings
    {
        public Bookings()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        [Key]
        public int BookingId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BookingDate { get; set; }
        [StringLength(50)]
        public string BookingNo { get; set; }
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }
        [StringLength(1)]
        public string TripTypeId { get; set; }
        public int? PackageId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Bookings))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(PackageId))]
        [InverseProperty(nameof(Packages.Bookings))]
        public virtual Packages Package { get; set; }
        [ForeignKey(nameof(TripTypeId))]
        [InverseProperty(nameof(TripTypes.Bookings))]
        public virtual TripTypes TripType { get; set; }
        [InverseProperty("Booking")]
       
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
