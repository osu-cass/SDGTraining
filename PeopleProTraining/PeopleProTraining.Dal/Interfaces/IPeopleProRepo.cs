using PeopleProTraining.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Interfaces
{
    public interface IPeopleProRepo
    {
        #region access

        #region employees
        IQueryable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate);

        Employee GetEmployee(Func<Employee, bool> predicate);
        Employee GetEmployee(int id);
        #endregion

        #region buildings
        IQueryable<Building> GetBuildings();
        IEnumerable<Building> GetBuildings(Func<Building, bool> predicate);

        Building GetBuilding(Func<Building, bool> predicate);
        Building GetBuilding(int id);
        #endregion

        #region departments
        IQueryable<Department> GetDepartments();
        IEnumerable<Department> GetDepartments(Func<Department, bool> predicate);

        Department GetDepartment(Func<Department, bool> predicate);
        Department GetDepartment(int id);
        #endregion
        #endregion

        #region save
        void SaveEmployee(Employee employee);
        #endregion
    }
}
