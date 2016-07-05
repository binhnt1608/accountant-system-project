using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class InventoryDiametersController : Controller
    {
        private ApplicationDbContext _context;

        public InventoryDiametersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InventoryDiameters
        public IActionResult Index()
        {
            return View(_context.InventoryDiameter.ToList());
        }

        // GET: InventoryDiameters/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryDiameter inventoryDiameter = _context.InventoryDiameter.Single(m => m.InventoryDiameterID == id);
            if (inventoryDiameter == null)
            {
                return HttpNotFound();
            }

            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryDiameters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventoryDiameter inventoryDiameter)
        {
            if (ModelState.IsValid)
            {
                _context.InventoryDiameter.Add(inventoryDiameter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryDiameter inventoryDiameter = _context.InventoryDiameter.Single(m => m.InventoryDiameterID == id);
            if (inventoryDiameter == null)
            {
                return HttpNotFound();
            }
            return View(inventoryDiameter);
        }

        // POST: InventoryDiameters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InventoryDiameter inventoryDiameter)
        {
            if (ModelState.IsValid)
            {
                _context.Update(inventoryDiameter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryDiameter inventoryDiameter = _context.InventoryDiameter.Single(m => m.InventoryDiameterID == id);
            if (inventoryDiameter == null)
            {
                return HttpNotFound();
            }

            return View(inventoryDiameter);
        }

        // POST: InventoryDiameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            InventoryDiameter inventoryDiameter = _context.InventoryDiameter.Single(m => m.InventoryDiameterID == id);
            _context.InventoryDiameter.Remove(inventoryDiameter);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
