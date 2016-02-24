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
    public class BuildingsController : Controller
    {
        private PeopleProContext p_context = new PeopleProContext();

        // GET: Buildings
        public ActionResult Index()
        {
            return View(p_context.Buildings.ToList());
        }

        // GET: Buildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = p_context.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingId,BuildingName")] Building building)
        {
            if (ModelState.IsValid)
            {
                p_context.Buildings.Add(building);
                p_context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(building);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = p_context.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingId,BuildingName")] Building building)
        {
            if (ModelState.IsValid)
            {
                p_context.Entry(building).State = EntityState.Modified;
                p_context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(building);
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
