using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(_context.Customer.ToList());
        }

        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customer customer = _context.Customer.Single(m => m.CustomerID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            customer.CustomerState = customer.CustomerState.ToUpper();
            if (customer.CustomerState == "TN" || customer.CustomerState == "CM")
            {
                ModelState.AddModelError("CustomerStateError", "Customer State is invalid.");
            }
            if (ModelState.IsValid)
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customer customer = _context.Customer.Single(m => m.CustomerID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            customer.CustomerState = customer.CustomerState.ToUpper();
            if (customer.CustomerState == "AK" || customer.CustomerState == "HI")
            {
                ModelState.AddModelError("CustomerStateError", "Customer State is invalid.");
            }
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customer customer = _context.Customer.Single(m => m.CustomerID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Customer customer = _context.Customer.Single(m => m.CustomerID == id);
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
