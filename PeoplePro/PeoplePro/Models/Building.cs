using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeoplePro.Models
{
    public class Building
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
