using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }
    public class EmployeeMetaData
    {
        [Required]
        public string FirstName;
        [Required]
        public string LastName;
        [Display(Name = "Date of Employment")]
        public DateTime EmploymentDate;
    }


}
