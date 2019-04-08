using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseSite.Controllers
{
    public class AjaxTestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FirstAjax(string a)
        {
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}