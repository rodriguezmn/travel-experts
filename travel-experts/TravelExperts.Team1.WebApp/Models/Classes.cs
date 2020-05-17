using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Classes
    {
        public Classes()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        [Key]
        [StringLength(5)]
        public string ClassId { get; set; }
        [Required]
        [StringLength(20)]
        public string ClassName { get; set; }
        [StringLength(50)]
        public string ClassDesc { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
