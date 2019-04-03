using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplePro.Models
{
    public class DepartmentEmployees
    {
        public List<Employee> Employees;
        public SelectList Departments;
        public string Selected { get; set; }
        public string Search { get; set; }
    }
}
