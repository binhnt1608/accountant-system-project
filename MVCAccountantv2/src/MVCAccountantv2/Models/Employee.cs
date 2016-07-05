using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        public int EmployeeID { get; set; }
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Type ID")]
        public int EmployeeTypeID { get; set; }

        public virtual List<EmployeeType> Employeetypes { get; set; }
        
        public EmployeeType EmployeeType { get; set; }
    }
}
