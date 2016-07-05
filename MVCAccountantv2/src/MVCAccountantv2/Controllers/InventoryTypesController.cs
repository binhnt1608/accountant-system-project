using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class InventoryTypesController : Controller
    {
        private ApplicationDbContext _context;

        public InventoryTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InventoryTypes
        public IActionResult Index()
        {
            return View(_context.InventoryType.ToList());
        }

        // GET: InventoryTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryType inventoryType = _context.InventoryType.Single(m => m.InventoryTypeID == id);
            if (inventoryType == null)
            {
                return HttpNotFound();
            }

            return View(inventoryType);
        }

        // GET: InventoryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventoryType inventoryType)
        {
            if (ModelState.IsValid)
            {
                _context.InventoryType.Add(inventoryType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryType);
        }

        // GET: InventoryTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryType inventoryType = _context.InventoryType.Single(m => m.InventoryTypeID == id);
            if (inventoryType == null)
            {
                return HttpNotFound();
            }
            return View(inventoryType);
        }

        // POST: InventoryTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InventoryType inventoryType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(inventoryType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryType);
        }

        // GET: InventoryTypes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryType inventoryType = _context.InventoryType.Single(m => m.InventoryTypeID == id);
            if (inventoryType == null)
            {
                return HttpNotFound();
            }

            return View(inventoryType);
        }

        // POST: InventoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            InventoryType inventoryType = _context.InventoryType.Single(m => m.InventoryTypeID == id);
            _context.InventoryType.Remove(inventoryType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
