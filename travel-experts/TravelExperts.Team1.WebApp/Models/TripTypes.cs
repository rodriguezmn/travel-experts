using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class TripTypes
    {
        public TripTypes()
        {
            Bookings = new HashSet<Bookings>();
        }

        [Key]
        [StringLength(1)]
        public string TripTypeId { get; set; }
        [Column("TTName")]
        [StringLength(25)]
        public string Ttname { get; set; }

        [InverseProperty("TripType")]
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
