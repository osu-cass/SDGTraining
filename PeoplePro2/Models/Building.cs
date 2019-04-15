using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeoplePro2.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }

        [Required]
        public string Name { get; set; }

        //navigation property for departments
        public virtual ICollection<Department> Departments { get; set; }
    }
}
