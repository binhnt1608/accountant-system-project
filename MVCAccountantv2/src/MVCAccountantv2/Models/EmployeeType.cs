using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCAccountantv2.Models
{
    public class EmployeeType
    {
        [Display(Name = "ID")]
        public int EmployeeTypeID { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeTypeName { get; set; }
    }
}
