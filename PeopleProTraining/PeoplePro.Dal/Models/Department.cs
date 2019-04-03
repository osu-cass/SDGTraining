using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeoplePro.Dal.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int BuildingId { get; set; }  // foreign key

        // the Building this Employee belongs to
        public virtual Building Building { get; set; }
        
        // collection of Employees that belong to this Department
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
