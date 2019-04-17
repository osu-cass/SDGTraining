using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web;
using DatabaseSite.Models;

namespace DatabaseSite.Models
{
    public class SignInAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Controller.ViewBag.Login = "Sign Out";
                filterContext.Controller.ViewBag.LoginAction = "LogOut";
            }
            else
            {
                filterContext.Controller.ViewBag.Login = "Sign In";
                filterContext.Controller.ViewBag.LoginAction = "Index";
            }
        }
    }
}