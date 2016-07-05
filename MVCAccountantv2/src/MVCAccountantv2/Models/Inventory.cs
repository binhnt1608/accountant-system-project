using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        [Display(Name = "Description")]

        [Required]
        public string InventoryDescription { get; set; }

        [Display(Name = "Composition")]
        public int InventoryCompositionID { get; set; }

        [Display(Name = "Type")]
        public int InventoryTypeID { get; set; }

        [Display(Name = "Diameter")]
        public int InventoryDiameterID { get; set; }

        [Required]
        [Range(0,10000)]
        [Display(Name ="List Price")]
        public string InventoryListPrice { get; set; }

       // public virtual List<InventoryComposition> InventoryCompositions { get; set }

        public InventoryComposition InventoryComposition { get; set; }

        public InventoryType InventoryType { get; set; }

        public InventoryDiameter InventoryDiameter { get; set; }
    }
}
