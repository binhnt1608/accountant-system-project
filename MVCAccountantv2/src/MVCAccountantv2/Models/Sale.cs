using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Sale
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime ShippingDate { get; set; }
        public int CustomerID { get; set; }
        public int SaleOrderID { get; set; }
        public int EmployeeID { get; set; }
        public int SaleAmount { get; set; }
      //  public virtual List<SaleOrder> SaleOrders { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<Employee> Employees { get; set; }

       // public SaleOrder SaleOrder { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }
    }
}
