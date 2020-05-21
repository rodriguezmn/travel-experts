//Added by Irada to make the Packages View display the Total price to customers. Do not Delete!

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExperts.Team1.WebApp.Models
{
    public class PackagesViewModel
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        [DisplayName("Trip Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}" )]
        public DateTime? PkgStartDate { get; set; }
        [DisplayName("Trip End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PkgEndDate { get; set; }
        [DisplayName("Trip Description")]
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public string PkgImage { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        // Total price to display to customer
        [DisplayName("Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        public decimal PkgTotalPrice { get; set; }
    }
}
