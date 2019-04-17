using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSite.Models
{
    public class EmployeeMetadata
    {
        [Required]
        [Display(Name = "First")]
        public string FirstName;

        [Required]
        [Display(Name = "Last")]
        public string LastName;
    }

    public class DepartmentMetadata
    {
        [Required]
        [Display(Name = "Department")]
        [RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string Name;
    }

    public class BuildingMetadata
    {
        [Required]
        [Display(Name = "Building")]
        public string Name;
    }
}