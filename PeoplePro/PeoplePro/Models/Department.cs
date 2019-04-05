using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplePro.Models
{
    public class Department
    {
        public int Id { get; set; }

        public List<Employee> Employees;
        [Required]
        [RegularExpression(@"[a-zA-Z\s]*$", ErrorMessage = "Department name must contain only uppercase and lower case letters")]

        public string Name { get; set; }
        [Required]

        public string Building { get; set; }
    }
}