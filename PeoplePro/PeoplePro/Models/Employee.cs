using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeoplePro.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
