using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CashAccount> CashAccount { get; set; }
        public DbSet<CashDisbursement> CashDisbursement { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<InventoryComposition> InventoryComposition { get; set; }
        public DbSet<InventoryType> InventoryType { get; set; }
        public DbSet<InventoryDiameter> InventoryDiameter { get; set; }
        public DbSet<SaleOrder> SaleOrder { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<OutFlow_SaleInventory> OutFlow_SaleInventory { get; set; }
        public DbSet<Reservation_SaleOrderInventory> Reservation_SaleOrderInventory { get; set; }
    }
}
