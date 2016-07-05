using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class VendorsController : Controller
    {
        private ApplicationDbContext _context;

        public VendorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Vendors
        public IActionResult Index()
        {
            return View(_context.Vendor.ToList());
        }

        // GET: Vendors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Vendor vendor = _context.Vendor.Single(m => m.VendorID == id);
            if (vendor == null)
            {
                return HttpNotFound();
            }

            return View(vendor);
        }

        // GET: Vendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Vendor.Add(vendor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Vendor vendor = _context.Vendor.Single(m => m.VendorID == id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(vendor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Vendor vendor = _context.Vendor.Single(m => m.VendorID == id);
            if (vendor == null)
            {
                return HttpNotFound();
            }

            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = _context.Vendor.Single(m => m.VendorID == id);
            _context.Vendor.Remove(vendor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
