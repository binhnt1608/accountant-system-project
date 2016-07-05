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
    public class CashDisbursementsController : Controller
    {
        private ApplicationDbContext _context;

        public CashDisbursementsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CashDisbursements
        public IActionResult Index()
        {
            var applicationDbContext = _context.CashDisbursement.Include(c => c.CashAccount).Include(c => c.Employee).Include(c => c.Vendor);
            return View(applicationDbContext.ToList());
        }

        // GET: CashDisbursements/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CashDisbursement cashDisbursement = _context.CashDisbursement.Single(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return HttpNotFound();
            }

            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Create
        public IActionResult Create()
        {
            ViewBag.Items1 = GetCashAccountsListItems();
            ViewBag.Items2 = GetEmployeesListItems();
            ViewBag.Items3 = GetVendorsListItems();
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "CashAccount");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "Vendor");
            return View();
        }

        private IEnumerable<SelectListItem> GetCashAccountsListItems(int selected = -1)
        {
            var tmp = _context.CashAccount.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(cashAccount => cashAccount.CashAccountID)
                .Select(cashAccount => new SelectListItem
                {
                    Text = String.Format("{0}", cashAccount.CashAccountID),
                    Value = cashAccount.CashAccountID.ToString(),
                    Selected = cashAccount.CashAccountID == selected
                });
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

        // POST: CashDisbursements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CashDisbursement cashDisbursement)
        {
            if (ModelState.IsValid)
            {
                _context.CashDisbursement.Add(cashDisbursement);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "CashAccount", cashDisbursement.CashAccountID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "Vendor", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CashDisbursement cashDisbursement = _context.CashDisbursement.Single(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return HttpNotFound();
            }
            ViewBag.Items1 = GetCashAccountsListItems();
            ViewBag.Items2 = GetEmployeesListItems();
            ViewBag.Items3 = GetVendorsListItems();
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "CashAccount");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "Vendor");
            return View(cashDisbursement);
        }

        // POST: CashDisbursements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CashDisbursement cashDisbursement)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cashDisbursement);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "CashAccount", cashDisbursement.CashAccountID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Employee", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "Vendor", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CashDisbursement cashDisbursement = _context.CashDisbursement.Single(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return HttpNotFound();
            }

            return View(cashDisbursement);
        }

        // POST: CashDisbursements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CashDisbursement cashDisbursement = _context.CashDisbursement.Single(m => m.CheckNumber == id);
            _context.CashDisbursement.Remove(cashDisbursement);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
