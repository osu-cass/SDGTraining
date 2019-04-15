using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeoplePro2.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //foreignkey
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        //navigation property
        public virtual Department Department { get; set; }

    }

}
