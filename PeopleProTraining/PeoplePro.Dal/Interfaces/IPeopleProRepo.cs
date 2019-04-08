﻿using PeoplePro.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Interfaces
{
    public interface IPeopleProRepo
    {
        IQueryable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate);

        Employee GetEmployee(Func<Employee, bool> predicate);
        Employee GetEmployee(int id);
    }
}
