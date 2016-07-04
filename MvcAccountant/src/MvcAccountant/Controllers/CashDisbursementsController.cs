using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MvcAccountant.Models;

namespace MvcAccountant.Controllers
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
            var applicationDbContext = _context.CashDisbursement.Include(c => c.CashAccount);
            return View(applicationDbContext.ToList());
        }

        // GET: CashDisbursements/Details/5
        public IActionResult Details(string id)
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
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "CashAccount");
            return View();
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
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Edit/5
        public IActionResult Edit(string id)
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
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "CashAccount", cashDisbursement.CashAccountID);
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
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
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
        public IActionResult DeleteConfirmed(string id)
        {
            CashDisbursement cashDisbursement = _context.CashDisbursement.Single(m => m.CheckNumber == id);
            _context.CashDisbursement.Remove(cashDisbursement);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
