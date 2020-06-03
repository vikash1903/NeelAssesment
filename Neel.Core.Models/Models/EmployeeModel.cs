using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neel.Core.Models.Models
{
    public class EmployeeModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        [Display(Name = "Contact Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        public string Salary { get; set; }
    }
}
