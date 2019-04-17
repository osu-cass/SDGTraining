using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using DatabaseSite.Models;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSite.Controllers
{
    public class AjaxController : Controller
    {
        private PeopleProDatabaseEntities db = new PeopleProDatabaseEntities();
        [HttpPost]
        public ActionResult FirstAjax(string name)
        {

            
            var dep = new Department
            {
                Name = name,
                //DepartmentId = db.Departments.Count()
            };

            if(TryValidateModel(dep) && User.Identity.IsAuthenticated)
            {

                db.Departments.Add(dep);
                db.SaveChanges();
                return PartialView("~/Views/Shared/Partials/DepartmentPartial.cshtml", dep);
            }
            else if (TryValidateModel(dep))
            {
                 return new HttpStatusCodeResult(403,"Not Logged in");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //return Json(dep, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CreatePrompt()
        {
            return PartialView("~/Views/Shared/Partials/CreateDepartmentPartial.cshtml");
        }
    }
}