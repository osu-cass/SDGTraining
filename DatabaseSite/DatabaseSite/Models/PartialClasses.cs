using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSite.Models
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
    }
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department
    {
    }
    [MetadataType(typeof(BuildingMetadata))]
    public partial class Building
    {
    }
}