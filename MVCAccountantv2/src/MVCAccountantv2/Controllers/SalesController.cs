using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Sales
        public IActionResult Index()
        {
            var applicationDbContext = _context.Sale.Include(s => s.Customer).Include(s => s.Employee);
            return View(applicationDbContext.ToList());
        }

        // GET: Sales/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sale sale = _context.Sale.Single(m => m.InvoiceID == id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee");
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Sale.Add(sale);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", sale.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", sale.EmployeeID);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sale sale = _context.Sale.Single(m => m.InvoiceID == id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", sale.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", sale.EmployeeID);
            return View(sale);
        }

        // POST: Sales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sale);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", sale.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", sale.EmployeeID);
            return View(sale);
        }

        // GET: Sales/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sale sale = _context.Sale.Single(m => m.InvoiceID == id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Sale sale = _context.Sale.Single(m => m.InvoiceID == id);
            _context.Sale.Remove(sale);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
