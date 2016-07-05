using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Purchase
    {
        [Key]
        [Display(Name = "ID")]
        public int ReceivingReportID { get; set; }
        [Display(Name = "Date")]
        public DateTime ReceivingReportDate { get; set; }
        [Display(Name = "Vendor Invoice ID")]
        public int ReceivingReportVendorInvoiceID { get; set; }
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }
        [Display(Name = "Vendor")]
        public string VendorID { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public virtual List<Vendor> Vendors { get; set; }

        public Employee Employee { get; set; }

        public Vendor Vendor { get; set; }
    }
}
