using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeoplePro.Models
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [ForeignKey("BuildingID")]
        public int BuildingID { get; set; }

        public virtual Building Building { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
