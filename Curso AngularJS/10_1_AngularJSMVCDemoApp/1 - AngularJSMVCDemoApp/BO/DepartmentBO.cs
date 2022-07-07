using AngularJSMVCDemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCrudOperationDemoApp
{
    public class DepartmentBO
    {
        private OrganizationDbEntities db = new OrganizationDbEntities();
        public IEnumerable<Department> GetAllDepartments()
        {
            return db.Departments;
        }
    }
}