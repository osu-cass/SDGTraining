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
using PeopleProTraining.Dal.Interfaces;

namespace PeopleProTraining.Controllers
{
    public class EmployeesController : Controller
    {
        private IPeopleProRepo p_repo = new PeopleProRepo();

        // GET: Employees
        public ActionResult Index()
        {
            return View(p_repo.GetEmployees().ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = p_repo.GetEmployee((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.BuildingBuildingId = new SelectList(p_repo.GetBuildings(), "BuildingId", "BuildingName");
            ViewBag.DepartmentDepartmentId = p_repo.GetDepartments().Select(t => new SelectListItem() { Text = t.DepartmentName, Value = t.DepartmentId.ToString() });
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DepartmentDepartmentId,BuildingBuildingId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                p_repo.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            ViewBag.BuildingBuildingId = new SelectList(p_repo.GetBuildings(), "BuildingId", "BuildingName", employee.BuildingBuildingId);
            ViewBag.DepartmentDepartmentId = p_repo.GetDepartments().Select(t => new SelectListItem() { Text = t.DepartmentName, Value = t.DepartmentId.ToString() });
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = p_repo.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingBuildingId = new SelectList(p_repo.GetBuildings(), "BuildingId", "BuildingName", employee.BuildingBuildingId);
            ViewBag.DepartmentDepartmentId = new SelectList(p_repo.GetDepartments(), "DepartmentId", "DepartmentName", employee.DepartmentDepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DepartmentDepartmentId,BuildingBuildingId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                p_repo.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            ViewBag.BuildingBuildingId = new SelectList(p_repo.GetBuildings(), "BuildingId", "BuildingName", employee.BuildingBuildingId);
            ViewBag.DepartmentDepartmentId = p_repo.GetDepartments().Select(t => new SelectListItem() { Text = t.DepartmentName, Value = t.DepartmentId.ToString() });
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = p_repo.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_repo.DeleteEmployee(p_repo.GetEmployee(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           p_repo.Dispose(disposing);
           base.Dispose(disposing);
        }
    }
}
