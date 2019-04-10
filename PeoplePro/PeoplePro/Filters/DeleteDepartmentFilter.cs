using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeoplePro.Models;
using PeoplePro.Controllers;

namespace PeoplePro.Filters
{
    public class DeleteDepartmentFilter : IActionFilter
    {
        private readonly PeopleProContext _context;

        public DeleteDepartmentFilter(PeopleProContext context)
        {
            _context = context;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //our code after exection
            throw new NotImplementedException();
        }

        public async Task OnActionExecuting(ActionExecutingContext context)
        {
            //our code before action executes
            var param = context.ActionArguments.FirstOrDefault();
            var department = _context.Department.Find(param.Value);

            if (department != null)
            {
                _context.Entry(department).Collection(x => x.Employees).Load();
                if (department.Employees.Count != 0)
                {
                    context.Result = new BadRequestObjectResult("Employees is not empty");
                    return;
                } else
                {
                    var depController = context.Controller as DepartmentController;
                    await depController.DeleteConfirmed(param.Value[1]);
                }
            }
            throw new NotImplementedException();
        }
    }
}
