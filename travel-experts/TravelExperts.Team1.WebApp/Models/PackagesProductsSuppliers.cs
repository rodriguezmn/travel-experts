using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    [Table("Packages_Products_Suppliers")]
    public partial class PackagesProductsSuppliers
    {
        [Key, Column(Order = 0)]
        public int PackageId { get; set; }
        [Key, Column(Order = 1)]
        public int ProductSupplierId { get; set; }

        [ForeignKey(nameof(PackageId))]
        [InverseProperty(nameof(Packages.PackagesProductsSuppliers))]
        public virtual Packages Package { get; set; }
        [ForeignKey(nameof(ProductSupplierId))]
        [InverseProperty(nameof(ProductsSuppliers.PackagesProductsSuppliers))]
        public virtual ProductsSuppliers ProductSupplier { get; set; }
    }
}
