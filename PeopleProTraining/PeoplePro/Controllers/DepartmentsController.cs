using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeoplePro.Models;

namespace PeoplePro.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly PeopleProContext _context;

        public DepartmentsController(PeopleProContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var peopleProContext = _context.Departments.Include(d => d.Building);
            return View(await peopleProContext.ToListAsync());
        }
        
        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Building)
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // AJAX GET: Departments/Add
        public IActionResult Add()
        {
            ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name");
            ViewBag.AddOrEdit = "Add";

            return PartialView("_AddEditModal", new Department());
        }

        // AJAX POST: Departments/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Id,Name,BuildingId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                _context.SaveChanges();

                Department newDepartment = _context.Departments
                    .Include(d => d.Building)
                    .ToList()
                    .FirstOrDefault(d => d.Id == department.Id);

                return PartialView("_Row", newDepartment);
            }
            return Json(new { err = true });
        }

        // GET: Departments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department model = _context.Departments
                .Include(d => d.Building)
                .FirstOrDefault(d => d.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name");
            ViewBag.AddOrEdit = "Edit";

            return PartialView("_AddEditModal", model);
        }

        // AJAX POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,BuildingId")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    _context.SaveChanges();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }

                Department updatedDepartment = _context.Departments
                    .Include(d => d.Building)
                    .ToList()
                    .FirstOrDefault(d => d.Id == department.Id);

                return PartialView("_Row", updatedDepartment);
            }
            ViewData["BuildingId"] = new SelectList(_context.Set<Building>(), "Id", "Name", department.BuildingId);
            return View(department);
        }

        // AJAX GET: Departments/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _context.Departments
                .Include(d => d.Building)
                .FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return PartialView("_ConfirmModal", model);
        }

        // AJAX POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return Json(new { id });
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
