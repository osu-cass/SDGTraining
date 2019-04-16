using PeoplePro.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplePro.Models
{
    public class DepartmentsViewModel
    {
        public List<Department> Departments { get; set; }

        //public Department Department { get; set; }

        public List<Building> Buildings { get; set; }
    }
}
