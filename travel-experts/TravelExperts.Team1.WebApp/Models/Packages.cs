using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Bookings = new HashSet<Bookings>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSuppliers>();
        }

        [Key]
        public int PackageId { get; set; }
        [Required]
        [StringLength(50)]
        public string PkgName { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Trip Starts")]
        public DateTime? PkgStartDate { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Trip Ends")]
        public DateTime? PkgEndDate { get; set; }
        [StringLength(50)]
        public string PkgDesc { get; set; }
        [Column(TypeName = "money")]
        public decimal PkgBasePrice { get; set; }
        [Required]
        [StringLength(50)]
        public string PkgImage { get; set; }
        [Column(TypeName = "money")]
        public decimal? PkgAgencyCommission { get; set; }

        [InverseProperty("Package")]
        public virtual ICollection<Bookings> Bookings { get; set; }
        [InverseProperty("Package")]
        public virtual ICollection<PackagesProductsSuppliers> PackagesProductsSuppliers { get; set; }      
    }
}
