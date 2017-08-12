using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
    }

    public class DepartmentMetaData
    {
        [Display(Name = "Staff Count")]
        public int StaffCount { get; set; }

        [Display(Name = "Department ID")]
        [Required (ErrorMessage = "Department id required.")]
        public int DepartmentId { get; set; }

        [Display (Name = "Department Name")]
        [Required (ErrorMessage = "Department names must be between 3 and 20 characters long.")]
        [StringLength (20, MinimumLength = 3)]
        public string DepartmentName { get; set; }
    }
}