using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class CashAccount
    {
        [Display(Name = "ID")]
        public int CashAccountID { get; set; }
        [Display(Name = "Description")]
        public string AccountDescription { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Bank Account Number")]
        public string BankAccountNumber { get; set; }
    }
}
