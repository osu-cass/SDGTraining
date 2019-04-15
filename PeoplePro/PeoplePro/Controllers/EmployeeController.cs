using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeoplePro.Models;

namespace PeoplePro.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PeopleProContext _context;

        public EmployeeController(PeopleProContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var peopleProContext = _context.Employee.Include(d => d.Building).Include(d => d.Department);
            return View(await peopleProContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(d=>d.Building)
                .Include(d=>d.Department)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "ID", "ID");
            ViewData["BuildingID"] = new SelectList(_context.Set<Building>(), "ID", "ID");
            ViewBag.Building = new SelectList(_context.Set<Building>(), "ID", "Name");
            ViewBag.Department = new SelectList(_context.Set<Department>(), "ID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,BuildingID,DepartmentID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingID"] = new SelectList(_context.Set<Building>(), "ID", "ID", employee.BuildingID);
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "ID", "ID", employee.DepartmentID);
            ViewBag.Building = new SelectList(_context.Set<Building>(), "ID", "Name", employee.Building);
            ViewBag.Department = new SelectList(_context.Set<Department>(), "ID", "Name", employee.Department);
            return View(employee);
        }

        public IActionResult EmployeeModal()
        {
            var model = new Employee { };

            ViewData["BuildingID"] = new SelectList(_context.Set<Building>(), "ID", "ID");
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "ID", "ID");
            ViewBag.Building = new SelectList(_context.Set<Building>(), "ID", "Name");
            ViewBag.Department = new SelectList(_context.Set<Department>(), "ID", "Name");

            return PartialView("_EmployeeModalPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeModal(Employee model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return PartialView("_EmployeeModalPartial", model);
            }
            ViewBag.Department = new SelectList(_context.Set<Department>(), "ID", "Name");
            ViewBag.Building = new SelectList(_context.Set<Building>(), "ID", "Name");

            return PartialView("_EmployeeModalPartial", model);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["BuildingID"] = new SelectList(_context.Set<Building>(), "ID", "ID", employee.BuildingID);
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "ID", "ID", employee.DepartmentID);
            ViewBag.Building = new SelectList(_context.Set<Building>(), "ID", "Name", employee.Building);
            ViewBag.Department = new SelectList(_context.Set<Department>(), "ID", "Name", employee.Department);

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,BuildingID,DepartmentID")] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingID"] = new SelectList(_context.Set<Building>(), "ID", "ID", employee.BuildingID);
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "ID", "ID", employee.DepartmentID);
            ViewBag.Building = new SelectList(_context.Set<Building>(), "ID", "Name", employee.Building);
            ViewBag.Department = new SelectList(_context.Set<Department>(), "ID", "Name", employee.Department);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(d => d.Department)
                .Include(d => d.Building)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}
