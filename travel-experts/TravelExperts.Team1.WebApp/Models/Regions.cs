using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Regions
    {
        public Regions()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        [Key]
        [StringLength(5)]
        public string RegionId { get; set; }
        [StringLength(25)]
        public string RegionName { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
