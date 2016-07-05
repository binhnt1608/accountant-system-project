using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class InventoryType
    {
        public int InventoryTypeID { get; set; }

        [Display(Name = "Type Code")]
        public string InventoryTypeCode { get; set; }

        [Display(Name = "Type Description")]
        public string InventoryTypeDescription { get; set; }
    }
}
