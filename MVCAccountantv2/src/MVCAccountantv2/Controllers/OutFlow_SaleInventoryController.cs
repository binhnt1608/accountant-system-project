using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class OutFlow_SaleInventoryController : Controller
    {
        private ApplicationDbContext _context;

        public OutFlow_SaleInventoryController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: OutFlow_SaleInventory
        public IActionResult Index()
        {
            var applicationDbContext = _context.OutFlow_SaleInventory.Include(o => o.Inventory);
            return View(applicationDbContext.ToList());
        }

        // GET: OutFlow_SaleInventory/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OutFlow_SaleInventory outFlow_SaleInventory = _context.OutFlow_SaleInventory.Single(m => m.InvoiceID == id);
            if (outFlow_SaleInventory == null)
            {
                return HttpNotFound();
            }

            return View(outFlow_SaleInventory);
        }

        // GET: OutFlow_SaleInventory/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory");
            return View();
        }

        // POST: OutFlow_SaleInventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OutFlow_SaleInventory outFlow_SaleInventory)
        {
            if (ModelState.IsValid)
            {
                _context.OutFlow_SaleInventory.Add(outFlow_SaleInventory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory", outFlow_SaleInventory.InventoryID);
            return View(outFlow_SaleInventory);
        }

        // GET: OutFlow_SaleInventory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OutFlow_SaleInventory outFlow_SaleInventory = _context.OutFlow_SaleInventory.Single(m => m.InvoiceID == id);
            if (outFlow_SaleInventory == null)
            {
                return HttpNotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory", outFlow_SaleInventory.InventoryID);
            return View(outFlow_SaleInventory);
        }

        // POST: OutFlow_SaleInventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OutFlow_SaleInventory outFlow_SaleInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(outFlow_SaleInventory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory", outFlow_SaleInventory.InventoryID);
            return View(outFlow_SaleInventory);
        }

        // GET: OutFlow_SaleInventory/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OutFlow_SaleInventory outFlow_SaleInventory = _context.OutFlow_SaleInventory.Single(m => m.InvoiceID == id);
            if (outFlow_SaleInventory == null)
            {
                return HttpNotFound();
            }

            return View(outFlow_SaleInventory);
        }

        // POST: OutFlow_SaleInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            OutFlow_SaleInventory outFlow_SaleInventory = _context.OutFlow_SaleInventory.Single(m => m.InvoiceID == id);
            _context.OutFlow_SaleInventory.Remove(outFlow_SaleInventory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
