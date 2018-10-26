using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleProTraining.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Building")]
        public int BuildingID { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [Display(Name= "First Name")]
        [Required]
        [StringLength(50)]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Date of Employment")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-DD}", ApplyFormatInEditMode = true)]
        public DateTime EmploymentDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Building OfficeBuildingLocation { get; set; }
    }
}