using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class InventoryComposition
    {
        public int InventoryCompositionID { get; set; }

        [Display(Name = "Composition Code")]
        public string InventoryCompositionCode { get; set; }

        [Display(Name = "Description")]
        public string InventoryCompositionDescription { get; set; }
        
    }
}
