using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeoplePro.Models
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int BuildingId { get; set; }  // foreign key

        // the Building this Employee belongs to
        public virtual Building Building { get; set; }

        // collection of Employees that belong to this Department
        public virtual List<Employee> Employees { get; set; }
    }
}
