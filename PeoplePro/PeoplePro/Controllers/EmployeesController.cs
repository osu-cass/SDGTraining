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
    public class EmployeesController : Controller
    {
        private readonly PeopleProContext _context;

        public EmployeesController(PeopleProContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string selected)
        {

            IQueryable<string> DepartmentQuery = from b in _context.Department
                                                 orderby b.Name
                                                 select b.Name;
            var employees = from b in _context.Employee
                            select b;
            if (!string.IsNullOrEmpty(selected))
            {
                employees = employees.Where(s => s.Department == selected);
            }

            var DepEmp = new DepartmentEmployees
            {
                Departments = new SelectList(await DepartmentQuery.Distinct().ToListAsync()),
                Employees = await employees.ToListAsync()
            };
            return View(DepEmp);
        }

 /*       public async Task<IActionResult> Index(string department, int notUsed)
        {
            var employees = from e in _context.Employee
                            select e;
            if (!string.IsNullOrEmpty(department))
            {
                employees
            }
        }*/


        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Id,Department")] Employee employee)
        {
            var DepartmentQuery = from b in _context.Department
                                                 select b;
            var DepCheck = DepartmentQuery.Where(s => s.Name == employee.Department);


            if((!DepCheck.Any()))
            {
                ModelState.AddModelError("Department", "Please enter an existing department");
            }
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
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
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Id,Department")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            var DepartmentQuery = from b in _context.Department
                                  select b;
            var DepCheck = DepartmentQuery.Where(s => s.Name == employee.Department);


            if ((!DepCheck.Any()))
            {
                ModelState.AddModelError("Department", "Please enter an existing department");
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
                    if (!EmployeeExists(employee.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
