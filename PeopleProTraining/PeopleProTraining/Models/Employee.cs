using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleProTraining.Models
{    
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Date of Employment")]
        public DateTime EmploymentDate { get; set; }
        public virtual Department Department { get; set; }
    }
}
