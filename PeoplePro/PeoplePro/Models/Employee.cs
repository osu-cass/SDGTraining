using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeoplePro.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

        [ForeignKey("BuildingID")]
        public int BuildingID { get; set; }

        public virtual Building Building { get; set; }

        public virtual Department Department { get; set; }

    }
}
