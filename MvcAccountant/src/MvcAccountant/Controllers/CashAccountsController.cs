using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MvcAccountant.Models;

namespace MvcAccountant.Controllers
{
    public class CashAccountsController : Controller
    {
        private ApplicationDbContext _context;

        public CashAccountsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CashAccounts
        public IActionResult Index()
        {
            return View(_context.CashAccount.ToList());
        }

        // GET: CashAccounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CashAccount cashAccount = _context.CashAccount.Single(m => m.CashAccountID == id);
            if (cashAccount == null)
            {
                return HttpNotFound();
            }

            return View(cashAccount);
        }

        // GET: CashAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CashAccount cashAccount)
        {
            if (ModelState.IsValid)
            {
                _context.CashAccount.Add(cashAccount);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cashAccount);
        }

        // GET: CashAccounts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CashAccount cashAccount = _context.CashAccount.Single(m => m.CashAccountID == id);
            if (cashAccount == null)
            {
                return HttpNotFound();
            }
            return View(cashAccount);
        }

        // POST: CashAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CashAccount cashAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cashAccount);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cashAccount);
        }

        // GET: CashAccounts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CashAccount cashAccount = _context.CashAccount.Single(m => m.CashAccountID == id);
            if (cashAccount == null)
            {
                return HttpNotFound();
            }

            return View(cashAccount);
        }

        // POST: CashAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CashAccount cashAccount = _context.CashAccount.Single(m => m.CashAccountID == id);
            _context.CashAccount.Remove(cashAccount);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
