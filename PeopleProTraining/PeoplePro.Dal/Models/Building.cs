using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeoplePro.Dal.Models
{
    public class Building
    {
        public int Id { get; internal set; }
        public string Name { get; set; }

        // collection of Departments that locate in this Building
        public virtual ICollection<Department> Departments { get; set; }
    }
}
