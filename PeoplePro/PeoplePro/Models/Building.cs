﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplePro.Models
{
    public class Building
    {
        public List<DepartmentEmployees> Departments;

        public SelectList Buildings;
        public string Selected { get; set; }
        public string Search { get; set; }
    }
}
