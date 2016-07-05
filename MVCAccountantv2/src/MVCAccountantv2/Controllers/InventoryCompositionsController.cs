using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class InventoryCompositionsController : Controller
    {
        private ApplicationDbContext _context;

        public InventoryCompositionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InventoryCompositions
        public IActionResult Index()
        {
            return View(_context.InventoryComposition.ToList());
        }

        // GET: InventoryCompositions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryComposition inventoryComposition = _context.InventoryComposition.Single(m => m.InventoryCompositionID == id);
            if (inventoryComposition == null)
            {
                return HttpNotFound();
            }

            return View(inventoryComposition);
        }

        // GET: InventoryCompositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryCompositions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventoryComposition inventoryComposition)
        {
            if (ModelState.IsValid)
            {
                _context.InventoryComposition.Add(inventoryComposition);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryComposition);
        }

        // GET: InventoryCompositions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryComposition inventoryComposition = _context.InventoryComposition.Single(m => m.InventoryCompositionID == id);
            if (inventoryComposition == null)
            {
                return HttpNotFound();
            }
            return View(inventoryComposition);
        }

        // POST: InventoryCompositions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InventoryComposition inventoryComposition)
        {
            if (ModelState.IsValid)
            {
                _context.Update(inventoryComposition);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryComposition);
        }

        // GET: InventoryCompositions/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            InventoryComposition inventoryComposition = _context.InventoryComposition.Single(m => m.InventoryCompositionID == id);
            if (inventoryComposition == null)
            {
                return HttpNotFound();
            }

            return View(inventoryComposition);
        }

        // POST: InventoryCompositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            InventoryComposition inventoryComposition = _context.InventoryComposition.Single(m => m.InventoryCompositionID == id);
            _context.InventoryComposition.Remove(inventoryComposition);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
