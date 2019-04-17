using System.ComponentModel.DataAnnotations;

namespace PeoplePro.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Range(1, 150)]
        [Required]
        public int Age { get; set; }

        [Required]
        public int DepartmentId { get; set; }  // foreign key

        // the Department this Employee belongs to
        public virtual Department Department { get; set; }
    }
}
