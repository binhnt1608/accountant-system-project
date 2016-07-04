using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAccountant.Models
{
    public class CashDisbursement
    {
        [Key]
        public string CheckNumber { get; set; }
        public DateTime CashDisbursementDate { get; set; }
        
        public string EmployeeID { get; set; }
        public string VendorID { get; set; }

        public int CashAccountID { get; set; }
        public CashAccount CashAccount { get; set; }
        



    }
}
