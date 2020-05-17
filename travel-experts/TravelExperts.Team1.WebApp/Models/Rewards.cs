using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Rewards
    {
        public Rewards()
        {
            CustomersRewards = new HashSet<CustomersRewards>();
        }

        [Key]
        public int RewardId { get; set; }
        [StringLength(50)]
        public string RwdName { get; set; }
        [StringLength(50)]
        public string RwdDesc { get; set; }

        [InverseProperty("Reward")]
        public virtual ICollection<CustomersRewards> CustomersRewards { get; set; }
    }
}
