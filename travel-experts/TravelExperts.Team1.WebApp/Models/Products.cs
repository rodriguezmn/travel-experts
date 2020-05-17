using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Products
    {
        public Products()
        {
            ProductsSuppliers = new HashSet<ProductsSuppliers>();
        }

        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProdName { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductsSuppliers> ProductsSuppliers { get; set; }
    }
}
