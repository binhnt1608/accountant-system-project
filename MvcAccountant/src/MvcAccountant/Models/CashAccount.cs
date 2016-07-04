using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAccountant.Models
{
    public class CashAccount
    {
        public int CashAccountID { get; set; }
        public string AccountDescription { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
