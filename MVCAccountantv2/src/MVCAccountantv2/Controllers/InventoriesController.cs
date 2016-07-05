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
    public class InventoriesController : Controller
    {
        private ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Inventories
        public IActionResult Index()
        {
            var applicationDbContext = _context.Inventory.Include(i => i.InventoryComposition).Include(i => i.InventoryDiameter).Include(i => i.InventoryType);
            return View(applicationDbContext.ToList());
        }

        // GET: Inventories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Inventory inventory = _context.Inventory.Single(m => m.InventoryID == id);
            if (inventory == null)
            {
                return HttpNotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewBag.Items1 = GetInventoryCompositionListItems();
            ViewBag.Items2 = GetInventoryTypeListItems();
            ViewBag.Items3 = GetInventoryDiameterListItems();
            ViewData["InventoryCompositionID"] = new SelectList(_context.InventoryComposition, "InventoryCompositionID", "InventoryComposition");
            ViewData["InventoryDiameterID"] = new SelectList(_context.InventoryDiameter, "InventoryDiameterID", "InventoryDiameter");
            ViewData["InventoryTypeID"] = new SelectList(_context.InventoryType, "InventoryTypeID", "InventoryType");
            return View();
        }

        private IEnumerable<SelectListItem> GetInventoryCompositionListItems(int selected = -1)
        {
            var tmp = _context.InventoryComposition.ToList();
            // Create cashaccounts list for <select> dropdown
            return _context.InventoryComposition.ToList()
                .OrderBy(composition => composition.InventoryCompositionID)
                .Select(composition => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", composition.InventoryCompositionDescription, composition.InventoryCompositionCode),
                    Value = composition.InventoryCompositionID.ToString(),
                    Selected = composition.InventoryCompositionID == selected
                });
        }

        private IEnumerable<SelectListItem> GetInventoryTypeListItems(int selected = -1)
        {
            var tmp = _context.InventoryType.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(type => type.InventoryTypeID)
                .Select(type => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", type.InventoryTypeDescription, type.InventoryTypeCode),
                    Value = type.InventoryTypeID.ToString(),
                    Selected = type.InventoryTypeID == selected
                });
        }

        private IEnumerable<SelectListItem> GetInventoryDiameterListItems(int selected = -1)
        {
            var tmp = _context.InventoryDiameter.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(diameter => diameter.InventoryDiameterID)
                .Select(diameter => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", diameter.InventoryDiameterDescription, diameter.InventoryDiameterCode),
                    Value = diameter.InventoryDiameterID.ToString(),
                    Selected = diameter.InventoryDiameterID == selected
                });
        }

        // POST: Inventories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Inventory.Add(inventory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["InventoryCompositionID"] = new SelectList(_context.InventoryComposition, "InventoryCompositionID", "InventoryComposition", inventory.InventoryCompositionID);
            ViewData["InventoryDiameterID"] = new SelectList(_context.InventoryDiameter, "InventoryDiameterID", "InventoryDiameter", inventory.InventoryDiameterID);
            ViewData["InventoryTypeID"] = new SelectList(_context.InventoryType, "InventoryTypeID", "InventoryType", inventory.InventoryTypeID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Inventory inventory = _context.Inventory.Single(m => m.InventoryID == id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Items1 = GetInventoryCompositionListItems();
            ViewBag.Items2 = GetInventoryTypeListItems();
            ViewBag.Items3 = GetInventoryDiameterListItems();
            ViewData["InventoryCompositionID"] = new SelectList(_context.InventoryComposition, "InventoryCompositionID", "InventoryComposition", inventory.InventoryCompositionID);
            ViewData["InventoryDiameterID"] = new SelectList(_context.InventoryDiameter, "InventoryDiameterID", "InventoryDiameter", inventory.InventoryDiameterID);
            ViewData["InventoryTypeID"] = new SelectList(_context.InventoryType, "InventoryTypeID", "InventoryType", inventory.InventoryTypeID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(inventory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["InventoryCompositionID"] = new SelectList(_context.InventoryComposition, "InventoryCompositionID", "InventoryComposition", inventory.InventoryCompositionID);
            ViewData["InventoryDiameterID"] = new SelectList(_context.InventoryDiameter, "InventoryDiameterID", "InventoryDiameter", inventory.InventoryDiameterID);
            ViewData["InventoryTypeID"] = new SelectList(_context.InventoryType, "InventoryTypeID", "InventoryType", inventory.InventoryTypeID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Inventory inventory = _context.Inventory.Single(m => m.InventoryID == id);
            if (inventory == null)
            {
                return HttpNotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = _context.Inventory.Single(m => m.InventoryID == id);
            _context.Inventory.Remove(inventory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
