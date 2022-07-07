using AngularJSMVCDemoApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AngularJSMVCDemoAPP.BO
{
    public class EmployeeBO
    {
        private OrganizationDbEntities db = new OrganizationDbEntities();

        public Employee GetDetails(int id)
        {
            Employee employee = db.Employees.Find(id);
            return employee;
        }
        public IEnumerable GetAllEmployees()
        {
            return db.Employees.Include("Department");//.Select(emp => new { emp.EmpId, emp.EmpName, emp.EmpSalary, Department=emp.Department.DeptName });
        }
        public Employee Insert(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            //Send welcome message to emp by email/sms...
            return emp;
        }
        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
        protected  void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}