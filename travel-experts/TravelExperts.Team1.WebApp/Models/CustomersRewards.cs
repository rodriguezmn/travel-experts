using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    [Table("Customers_Rewards")]
    public partial class CustomersRewards
    {
        [Key]
        public int CustomerId { get; set; }
        [Key]
        public int RewardId { get; set; }
        [Required]
        [StringLength(25)]
        public string RwdNumber { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.CustomersRewards))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(RewardId))]
        [InverseProperty(nameof(Rewards.CustomersRewards))]
        public virtual Rewards Reward { get; set; }
    }
}
