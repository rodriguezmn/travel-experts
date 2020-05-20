//Added by Irada to make the Packages View display the Total price to customers. Do not Delete!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExperts.Team1.WebApp.Models
{
    public class PackagesViewModel
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; }
        public DateTime? PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public string PkgImage { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        // Total price to display to customer
        public decimal PkgTotalPrice { get; set; }
    }
}
