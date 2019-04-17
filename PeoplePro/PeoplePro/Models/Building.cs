using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplePro.Models
{
    public class Building
    {
        public int Id { get; set; }
    
        public List<Department> Departments;
        [Required]
        [RegularExpression(@"[a-zA-Z]*$", ErrorMessage = "Building name must be a single word containing only uppercase and lower case letters")]

        public string Name { get; set; } 
        [Required]
        public string Address { get; set; } 
    }
}
