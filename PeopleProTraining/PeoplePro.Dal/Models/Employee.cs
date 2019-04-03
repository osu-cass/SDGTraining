using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeoplePro.Dal.Models
{
    //[ModelMetadataType(typeof(EmployeeMetaData))]
    //public partial class Employee
    public class Employee
    {
        public int Id { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }  // foreign key

    }
    //public class EmployeeMetaData
    //{
    //    public int Id;

    //    [Required]
    //    public string FirstName;

    //    [Required]
    //    public string LastName;

    //    public string Age;

    //    [Required]
    //    public int DepartmentId { get; set; }
    //}
}
