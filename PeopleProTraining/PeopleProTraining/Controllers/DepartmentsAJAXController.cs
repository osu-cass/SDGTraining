using PeopleProTraining.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleProTraining.Controllers
{
    public class DepartmentsAJAXController : Controller
    {
        private PeopleProDataEntities db = new PeopleProDataEntities();

        // GET: DepartmentsAJAX
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(db.Departments, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Department department)
        {
            return Json(db.Departments.Add(department), JsonRequestBehavior.AllowGet);
        }
    }
}