using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TravelExperts.Team1.WebApp.Models
{
    // Karim Khan
    // Added User Authentication credentials to Customers Table
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
            CreditCards = new HashSet<CreditCards>();
            CustomersRewards = new HashSet<CustomersRewards>();
        }

        [Key]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string CustFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string CustLastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        [StringLength(75)]
        public string CustAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        [StringLength(50)]
        public string CustCity { get; set; }
        [Required]
        [Display(Name = "Province")]
        [StringLength(2)]
        public string CustProv { get; set; }
        [Required]
        [RegularExpression(@"([A-Z,0-9,A-Z]{3})[ ]([0-9,A-Z,0-9]{3})",
                ErrorMessage = "Entered postal code is not valid.")]
        [Display(Name = "Postal Code")]
        [StringLength(7)]
        public string CustPostal { get; set; }
        [Display(Name = "Country")]
        [StringLength(25)]
        public string CustCountry { get; set; }
        [StringLength(20)]
        public string CustHomePhone { get; set; }
        [Required]
        [RegularExpression(@"([0-9]{10})",
            ErrorMessage = "Entered phone format is not valid.")]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string CustBusPhone { get; set; }
        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string CustEmail { get; set; }
        [Required]
        [StringLength(16)]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(16)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int? AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        [InverseProperty(nameof(Agents.Customers))]
        public virtual Agents Agent { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Bookings> Bookings { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CreditCards> CreditCards { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomersRewards> CustomersRewards { get; set; }
    }
}
