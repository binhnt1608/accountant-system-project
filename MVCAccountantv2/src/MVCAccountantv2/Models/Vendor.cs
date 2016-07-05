using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Vendor
    {
        [Display(Name = "ID")]
        public int VendorID { get; set; }
        [Display(Name = "Name")]
        public string VendorName { get; set; }
    }
}
