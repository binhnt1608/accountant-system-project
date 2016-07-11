using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class Reservation_SaleOrderInventoryController : Controller
    {
        private ApplicationDbContext _context;

        public Reservation_SaleOrderInventoryController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Reservation_SaleOrderInventory
        public IActionResult Index()
        {
            var applicationDbContext = _context.Reservation_SaleOrderInventory.Include(r => r.Inventory);
            return View(applicationDbContext.ToList());
        }

        // GET: Reservation_SaleOrderInventory/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Reservation_SaleOrderInventory reservation_SaleOrderInventory = _context.Reservation_SaleOrderInventory.Single(m => m.SaleOrderID == id);
            if (reservation_SaleOrderInventory == null)
            {
                return HttpNotFound();
            }

            return View(reservation_SaleOrderInventory);
        }

        // GET: Reservation_SaleOrderInventory/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory");
            return View();
        }

        // POST: Reservation_SaleOrderInventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation_SaleOrderInventory reservation_SaleOrderInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Reservation_SaleOrderInventory.Add(reservation_SaleOrderInventory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory", reservation_SaleOrderInventory.InventoryID);
            return View(reservation_SaleOrderInventory);
        }

        // GET: Reservation_SaleOrderInventory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Reservation_SaleOrderInventory reservation_SaleOrderInventory = _context.Reservation_SaleOrderInventory.Single(m => m.SaleOrderID == id);
            if (reservation_SaleOrderInventory == null)
            {
                return HttpNotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory", reservation_SaleOrderInventory.InventoryID);
            return View(reservation_SaleOrderInventory);
        }

        // POST: Reservation_SaleOrderInventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservation_SaleOrderInventory reservation_SaleOrderInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(reservation_SaleOrderInventory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "Inventory", reservation_SaleOrderInventory.InventoryID);
            return View(reservation_SaleOrderInventory);
        }

        // GET: Reservation_SaleOrderInventory/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Reservation_SaleOrderInventory reservation_SaleOrderInventory = _context.Reservation_SaleOrderInventory.Single(m => m.SaleOrderID == id);
            if (reservation_SaleOrderInventory == null)
            {
                return HttpNotFound();
            }

            return View(reservation_SaleOrderInventory);
        }

        // POST: Reservation_SaleOrderInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Reservation_SaleOrderInventory reservation_SaleOrderInventory = _context.Reservation_SaleOrderInventory.Single(m => m.SaleOrderID == id);
            _context.Reservation_SaleOrderInventory.Remove(reservation_SaleOrderInventory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
