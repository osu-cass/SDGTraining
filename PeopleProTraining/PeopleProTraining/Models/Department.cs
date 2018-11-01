using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleProTraining.Models
{
    public  class Department
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
