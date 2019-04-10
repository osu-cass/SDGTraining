using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeoplePro.Models;


namespace PeoplePro.Filters
{
    public class DeleteBuildingFilter : IActionFilter
    {
        private readonly PeopleProContext _context;

        public DeleteBuildingFilter(PeopleProContext context)
        {
            _context = context;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //our code after exection
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //our code before action executes
            var param = context.ActionArguments.FirstOrDefault();
            var building = _context.Building.Find(param.Value);

            if (building != null)
            {
                _context.Entry(building).Collection(x => x.Departments).Load();
                if (building.Departments.Count != 0)
                {
                    context.Result = new BadRequestObjectResult("Departments is not empty");
                    return;
                }
            }
            throw new NotImplementedException();
        }
    }
}
