using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplePro.Models
{
    public class Department
    {
        public int Id { get; set; }

        public List<Employee> Employees;

        public string Name { get; set; }

        public string Building { get; set; }
    }
}