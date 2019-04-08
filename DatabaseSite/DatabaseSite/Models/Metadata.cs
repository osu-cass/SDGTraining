using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSite.Models
{
    public class EmployeeMetadata
    {
        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName;

        [StringLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName;
    }

    public class DepartmentMetadata
    {
        [StringLength(50)]
        [Required]
        [Display(Name = "Department")]
        public string Name;
    }
    public class BuildingMetadata
    {
        [StringLength(50)]
        [Required]
        [Display(Name = "Building")]
        public string Name;
    }

}