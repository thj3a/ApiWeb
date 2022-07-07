using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Metadata;

namespace AngularJSMVCDemoApp
{
    public partial class EmployeeMetadata
    {
        public int EmpId { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string EmpName { get; set; }
        
        //[Required(ErrorMessage = "Salary is required")]
        public decimal EmpSalary { get; set; }


        public int DeptId { get; set; }
        
        public Nullable<bool> IsActive { get; set; }
    }
    [MetadataType(typeof(EmployeeMetadata))]
     public partial class Employee
    { }
}