using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            ProductsSuppliers = new HashSet<ProductsSuppliers>();
            SupplierContacts = new HashSet<SupplierContacts>();
        }

        [Key]
        public int SupplierId { get; set; }
        [StringLength(255)]
        public string SupName { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<ProductsSuppliers> ProductsSuppliers { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<SupplierContacts> SupplierContacts { get; set; }
    }
}
