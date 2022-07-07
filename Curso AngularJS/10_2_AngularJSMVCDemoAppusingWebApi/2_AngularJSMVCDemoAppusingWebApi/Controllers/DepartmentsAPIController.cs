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
        public Department Get(int id)
        {
            return deptBO.GetDetails(id);
        }

        // POST api/departmentsapi
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody]Department dept)
        {
            //throw new ApplicationException("a");
            if (ModelState.IsValid && dept != null)
            {
                deptBO.Insert(dept);
                //After inserting we are returning all the department records.
                return request.CreateResponse(HttpStatusCode.OK, deptBO.GetAllDepartments());
            }
            else
                return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        private IEnumerable<string> GetErrorMessages()
        {
            //Returns an array of error messages.
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }

        // PUT api/department/5
        public HttpResponseMessage Put(int id, [FromBody]Department dept)
        {
            //throw new ApplicationException("a");
            if (ModelState.IsValid && dept != null)
            {
                deptBO.Update(dept);
                //After inserting we are returning all the employee records.
                return Request.CreateResponse(HttpStatusCode.OK, deptBO.GetAllDepartments());
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        // DELETE api/department/5
        public HttpResponseMessage Delete(int id)
        {
            deptBO.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, deptBO.GetAllDepartments());
        }
    }
}
