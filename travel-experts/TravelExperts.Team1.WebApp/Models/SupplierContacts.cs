using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class SupplierContacts
    {
        [Key]
        public int SupplierContactId { get; set; }
        [StringLength(50)]
        public string SupConFirstName { get; set; }
        [StringLength(50)]
        public string SupConLastName { get; set; }
        [StringLength(255)]
        public string SupConCompany { get; set; }
        [StringLength(255)]
        public string SupConAddress { get; set; }
        [StringLength(255)]
        public string SupConCity { get; set; }
        [StringLength(255)]
        public string SupConProv { get; set; }
        [StringLength(255)]
        public string SupConPostal { get; set; }
        [StringLength(255)]
        public string SupConCountry { get; set; }
        [StringLength(50)]
        public string SupConBusPhone { get; set; }
        [StringLength(50)]
        public string SupConFax { get; set; }
        [StringLength(255)]
        public string SupConEmail { get; set; }
        [Column("SupConURL")]
        [StringLength(255)]
        public string SupConUrl { get; set; }
        [StringLength(10)]
        public string AffiliationId { get; set; }
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(AffiliationId))]
        [InverseProperty(nameof(Affiliations.SupplierContacts))]
        public virtual Affiliations Affiliation { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Suppliers.SupplierContacts))]
        public virtual Suppliers Supplier { get; set; }
    }
}
