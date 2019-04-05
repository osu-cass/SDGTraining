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

        public int DepartmentID { get; set; }

        public int BuildingID { get; set; }

    }
}
