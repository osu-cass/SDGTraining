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

        // AJAX GET: Departments/Add
        public IActionResult Add()
        {
            var model = new Department();

            ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name");

            return PartialView("_AddEditModal", model);
        }

        // AJAX POST: Departments/Add
        [HttpPost]
        public IActionResult Add([Bind("Id,Name,BuildingId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return Json(new { err = true });
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

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Set<Building>(), "Id", "Name", department.BuildingId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BuildingId")] Department department)
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
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
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
            return Json(new { id = id });
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
