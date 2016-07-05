using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Inflow_InventoryPurchase
    {
        public int ReceivingReportID { get; set; }

        public int InventoryItemID { get; set; }

        public int InventoryReceiptQuantity { get; set; }

    }
}
