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
    public class PurchasesController : Controller
    {
        private ApplicationDbContext _context;

        public PurchasesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Purchases
        public IActionResult Index()
        {
            var applicationDbContext = _context.Purchase.Include(p => p.Employee);
            return View(applicationDbContext.ToList());
        }

        // GET: Purchases/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Purchase purchase = _context.Purchase.Single(m => m.ReceivingReportID == id);
            if (purchase == null)
            {
                return HttpNotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewBag.Items2 = GetEmployeesListItems();
            ViewBag.Items3 = GetVendorsListItems();
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "Vendor");
            return View();
        }

        private IEnumerable<SelectListItem> GetEmployeesListItems(int selected = -1)
        {
            var tmp = _context.Employee.ToList();
            // Create employees list for <select> dropdown
            return tmp
                .OrderBy(employee => employee.EmployeeID)
                .Select(employee => new SelectListItem
                {
                    Text = String.Format("{0} - {1}", employee.EmployeeID, employee.EmployeeFirstName),
                    Value = employee.EmployeeID.ToString(),
                    Selected = employee.EmployeeID == selected
                });
        }

        private IEnumerable<SelectListItem> GetVendorsListItems(int selected = -1)
        {
            var tmp = _context.Vendor.ToList();
            // Create vendors list for <select> dropdown
            return tmp
                .OrderBy(vendor => vendor.VendorID)
                .Select(vendor => new SelectListItem
                {
                    Text = String.Format("{0} - {1}", vendor.VendorID, vendor.VendorName),
                    Value = vendor.VendorID.ToString(),
                    Selected = vendor.VendorID == selected
                });
        }

        // POST: Purchases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Purchase.Add(purchase);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", purchase.EmployeeID);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Purchase purchase = _context.Purchase.Single(m => m.ReceivingReportID == id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.Items2 = GetEmployeesListItems();
            ViewBag.Items3 = GetVendorsListItems();
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "Vendor");
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Update(purchase);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", purchase.EmployeeID);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Purchase purchase = _context.Purchase.Single(m => m.ReceivingReportID == id);
            if (purchase == null)
            {
                return HttpNotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = _context.Purchase.Single(m => m.ReceivingReportID == id);
            _context.Purchase.Remove(purchase);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
