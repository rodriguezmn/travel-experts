using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Fees
    {
        public Fees()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        [Key]
        [StringLength(10)]
        public string FeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string FeeName { get; set; }
        [Column(TypeName = "money")]
        public decimal FeeAmt { get; set; }
        [StringLength(50)]
        public string FeeDesc { get; set; }

        [InverseProperty("Fee")]
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
