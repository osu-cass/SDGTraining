using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeopleProTraining.Dal.Infrastructure;
using PeopleProTraining.Dal.Models;

namespace PeopleProTraining.Controllers
{
    public class DepartmentsController : Controller
    {
        private PeopleProContext p_context = new PeopleProContext();

        // GET: Departments
        public ActionResult Index()
        {
            return View(p_context.Departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = p_context.Departments.Find(id.Value);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentCode,StaffCount,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                p_context.Departments.Add(department);
                p_context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = p_context.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentCode,StaffCount,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                p_context.Entry(department).State = EntityState.Modified;
                p_context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                p_context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
