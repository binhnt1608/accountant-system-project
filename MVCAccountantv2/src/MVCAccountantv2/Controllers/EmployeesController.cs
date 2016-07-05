using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;
using Microsoft.Data.Entity.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MVCAccountantv2.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Employees
        public IActionResult Index()
        {
            var applicationDbContext = _context.Employee.Include(e => e.EmployeeType);
            return View(applicationDbContext.ToList());
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = _context.Employee.Single(m => m.EmployeeID == id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewBag.Items = GetEmployeeTypesListItems();
            ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeType");
            return View();
        }

        private IEnumerable<SelectListItem> GetEmployeeTypesListItems(int selected = -1)
        {
            var tmp = _context.EmployeeType.ToList();
            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(employeeType => employeeType.EmployeeTypeID)
                .Select(employeeType => new SelectListItem
                {
                    Text = String.Format("{0} - {1}", employeeType.EmployeeTypeID, employeeType.EmployeeTypeName),
                    Value = employeeType.EmployeeTypeID.ToString(),
                    Selected = employeeType .EmployeeTypeID == selected
                });
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = _context.Employee.Single(m => m.EmployeeID == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Items = GetEmployeeTypesListItems();
            ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeType");
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = _context.Employee.Single(m => m.EmployeeID == id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Employee employee = _context.Employee.Single(m => m.EmployeeID == id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
