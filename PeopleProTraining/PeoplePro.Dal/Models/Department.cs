using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeoplePro.Dal.Models
{
    public class Department
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public int BuildingId { get; set; }  // foreign key
        
        // collection of Employees that belong to this Department
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
