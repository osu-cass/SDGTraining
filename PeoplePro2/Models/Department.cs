using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeoplePro2.Models
{
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        //foreign key for Building
        [Display(Name = "Building")]
        public int BuildingId { get; set; }
        //navigation property for Building
        public virtual Building Building { get; set; }

        //nagivation property for employees
        [Display(Name = "Employees")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
