using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Reservation_SaleOrderInventory
    {
        [Key]
        public int SaleOrderID { get; set; }
        public int InventoryID { get; set; }
        public int QuantityOrdered { get; set; }
        public float SOPrice { get; set; }

        public virtual List<SaleOrder> SaleOrders { get; set; }

        public virtual List<Inventory> Inventories { get; set; }

        public SaleOrder SaleOrder { get; set; }

        public Inventory Inventory { get; set; }
    }
}