using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleProTraining.Models
{
    public class Building
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual Department Department { get; set; }
    }
    
}
