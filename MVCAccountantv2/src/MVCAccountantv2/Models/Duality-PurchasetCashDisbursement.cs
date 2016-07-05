using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Duality_PurchasetCashDisbursement
    {
        [Key]
        public string ReceivingReportID { get; set; }
        [Key]
        public string CheckNumber { get; set; }
        
    }
}
