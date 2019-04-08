using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeoplePro.Dal.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Range(1, 150)]
        [Required]
        public int Age { get; set; }

        [Required]
        public int DepartmentId { get; set; }  // foreign key

        // the Department this Employee belongs to
        public virtual Department Department { get; set; }
    }
}
