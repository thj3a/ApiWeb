using AngularJSMVCDemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCrudOperationDemoApp
{
    public class DepartmentBO
    {
        private OrgDemoDbEntities db = new OrgDemoDbEntities();
        public Department GetDetails(int id)
        {   
            Department department = db.Departments.Find(id);
            return department;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return db.Departments;
        }

        public Department Insert(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            return dept;
        }
        public void Update(Department dept)
        {
            db.Departments.Attach(dept);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Department objdepartment = db.Departments.Find(id);
            db.Departments.Remove(objdepartment);
            db.SaveChanges();
        }
        protected void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}