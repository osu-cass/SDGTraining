using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeoplePro.Models;

namespace PeoplePro.Filters
{
    public class DeleteDepartmentFilter : IAsyncActionFilter
    {
        private readonly PeopleProContext _context;

        public DeleteDepartmentFilter(PeopleProContext context)
        {
            _context = context;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //our code before action executes
            var param = context.ActionArguments.FirstOrDefault();
            var department = _context.Department.Find(param.Value);
            var departmentID = department.ID;

            if (department != null)
            {
                _context.Entry(department).Collection(x => x.Employees).Load();
                if (department.Employees.Count != 0)
                {
                    context.Result = new BadRequestObjectResult("Employees is not empty");
                }
                else
                {
                    var resultContext = await next();
                }
            }
            
            //do something after the action executes

        }
    }
}
