using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using DatabaseSite.Models;
using System.Data.Entity;

namespace DatabaseSite.Controllers
{
    [SignIn]
    public class LoginController : Controller
    {
        private PeopleProDatabaseEntities db = new PeopleProDatabaseEntities();
        // GET: Login
        public ActionResult Index()
        {
            //FormsAuthentication.SignOut();
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password")] Login data)
        {
            int valid = db.LoginDatas.Where(x => x.UserName == data.UserName && x.Password == data.Password).Count();
            if (valid > 0)
            {
                FormsAuthentication.SetAuthCookie(data.UserName, false);
                var employees = db.Employees.Include(e => e.Building).Include(e => e.Department);
                ViewBag.Login = "Sign Out";
                ViewBag.LoginAction = "LogOut";
                return View("~/Views/Employees/Index.cshtml", employees.ToList());
            }
            return View("~/Views/Login/Index.cshtml", data);
        }

        public ActionResult LogOut()
        {
            ViewBag.Login = "Sign In";
            ViewBag.LoginAction = "Login";
            FormsAuthentication.SignOut();
            return View("~/Views/Login/LogOut.cshtml");
        }
    }
}