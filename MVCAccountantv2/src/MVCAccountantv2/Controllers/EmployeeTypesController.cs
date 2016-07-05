using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class EmployeeTypesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EmployeeTypes
        public IActionResult Index()
        {
            return View(_context.EmployeeType.ToList());
        }

        // GET: EmployeeTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            EmployeeType employeeType = _context.EmployeeType.Single(m => m.EmployeeTypeID == id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }

            return View(employeeType);
        }

        // GET: EmployeeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                _context.EmployeeType.Add(employeeType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            EmployeeType employeeType = _context.EmployeeType.Single(m => m.EmployeeTypeID == id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employeeType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            EmployeeType employeeType = _context.EmployeeType.Single(m => m.EmployeeTypeID == id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }

            return View(employeeType);
        }

        // POST: EmployeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            EmployeeType employeeType = _context.EmployeeType.Single(m => m.EmployeeTypeID == id);
            _context.EmployeeType.Remove(employeeType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
