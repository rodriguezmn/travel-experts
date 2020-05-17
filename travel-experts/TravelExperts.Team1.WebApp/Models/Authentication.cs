using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Authentication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public string Username { get; set; }
        [Required]
        [StringLength(16)]
        public string Password { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Authentication))]
        public virtual Customers Customer { get; set; }
    }
}
