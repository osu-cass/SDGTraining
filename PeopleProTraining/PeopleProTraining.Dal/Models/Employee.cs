using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }

    public class EmployeeMetaData
    {
        [Display (Name = "Employee ID")]
        public int Id;

        [Display (Name = "First Name")]
        [Required (ErrorMessage = "First name required.")]
        public string FirstName { get; set; }

        [Display (Name = "Last Name")]
        [Required (ErrorMessage = "Last name required.")]
        [StringLength (20, MinimumLength = 1)]
        public string LastName { get; set; }
    }


}
