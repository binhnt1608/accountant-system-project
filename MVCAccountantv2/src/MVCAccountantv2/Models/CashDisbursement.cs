using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class CashDisbursement
    {
        [Key]
        [Display(Name = "Check Number")]
        public int CheckNumber { get; set; }
        [Display(Name = "Date")]
        public DateTime CashDisbursementDate { get; set; }
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }
        [Display(Name = "Cash Account")]
        public int CashAccountID { get; set; }

        //FK
        public virtual List<CashAccount> CashAccounts { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public virtual List<Vendor> Vendors { get; set; }

        public CashAccount CashAccount { get; set; }
        public Employee Employee { get; set; }
        public Vendor Vendor { get; set; }
    }
}
