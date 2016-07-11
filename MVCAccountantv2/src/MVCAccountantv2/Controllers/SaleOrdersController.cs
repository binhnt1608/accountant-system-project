using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class SaleOrdersController : Controller
    {
        private ApplicationDbContext _context;

        public SaleOrdersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SaleOrders
        public IActionResult Index()
        {
            var applicationDbContext = _context.SaleOrder.Include(s => s.Customer).Include(s => s.Employee);
            return View(applicationDbContext.ToList());
        }

        // GET: SaleOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SaleOrder saleOrder = _context.SaleOrder.Single(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            return View(saleOrder);
        }

        // GET: SaleOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee");
            return View();
        }

        // POST: SaleOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.SaleOrder.Add(saleOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // GET: SaleOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SaleOrder saleOrder = _context.SaleOrder.Single(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Update(saleOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SaleOrder saleOrder = _context.SaleOrder.Single(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            return View(saleOrder);
        }

        // POST: SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            SaleOrder saleOrder = _context.SaleOrder.Single(m => m.SaleOrderID == id);
            _context.SaleOrder.Remove(saleOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
