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

        [Required, StringLength(60, MinimumLength = 1), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Department { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(10), Required]
        public string Building { get; set; }

    }
}
