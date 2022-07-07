using EFCrudOperationDemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSMVCDemoApp.Controllers
{
    public class DepartmentsController : ApiController
    {
        DepartmentBO deptBO = new DepartmentBO();
        public DepartmentsController()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
        // GET api/departmentsapi
        public IEnumerable<Department> Get()
        {
            return deptBO.GetAllDepartments();
        }

        // GET api/departmentsapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/departmentsapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/departmentsapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/departmentsapi/5
        public void Delete(int id)
        {
        }
    }
}
