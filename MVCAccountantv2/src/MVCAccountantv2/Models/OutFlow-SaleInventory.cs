using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class OutFlow_SaleInventory
    {
        [Key]
        public int InvoiceID { get; set; }
        public int InventoryID { get; set; }
        public int QuantitySold { get; set; }
        public float InvoicePrive { get; set; }

        public virtual List<Sale> Sales { get; set; }

        public virtual List<Inventory> inventories { get; set; }

        public Sale Sale { get; set; }

        public Inventory Inventory { get; set; }
    }
}