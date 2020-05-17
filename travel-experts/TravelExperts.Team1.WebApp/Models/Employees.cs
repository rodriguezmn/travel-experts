using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class Employees
    {
        [Required]
        [StringLength(20)]
        public string EmpFirstName { get; set; }
        [StringLength(5)]
        public string EmpMiddleInitial { get; set; }
        [Required]
        [StringLength(20)]
        public string EmpLastName { get; set; }
        [Required]
        [StringLength(20)]
        public string EmpBusPhone { get; set; }
        [Required]
        [StringLength(50)]
        public string EmpEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string EmpPosition { get; set; }
    }
}
