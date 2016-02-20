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

        [Display(Name = "Department Code")]
        [Required (ErrorMessage = "Department code required.")]
        public int DepartmentId { get; set; }

        [Display (Name = "Department Name")]
        [Required (ErrorMessage = "Department name required.")]
        [StringLength (20, MinimumLength = 3)]
        public string DepartmentName { get; set; }
    }
}