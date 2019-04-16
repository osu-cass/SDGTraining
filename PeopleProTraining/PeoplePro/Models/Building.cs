using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeoplePro.Models
{
    public class Building
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        // collection of Departments that locate in this Building
        public virtual List<Department> Departments { get; set; }
    }
}
