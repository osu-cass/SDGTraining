﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Models
{
    [ModelMetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        public int Id { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class EmployeeMetaData
    {
        public int Id;

        [Required]
        public string FirstName;

        [Required]
        public string LastName;

        public string Age;
    }


}
