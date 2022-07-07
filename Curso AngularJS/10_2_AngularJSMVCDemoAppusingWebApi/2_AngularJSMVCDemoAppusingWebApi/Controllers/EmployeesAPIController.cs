using AngularJSMVCDemoAPP.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSMVCDemoApp.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeBO empBO = new EmployeeBO();
        // GET api/employeeapi
        public EmployeesController()
        {
            //Following is needed if the Employee properties are in camel case.
            //Ideally it should be written in Global.asax
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;  
        }
        public IEnumerable Get()
        {
            return empBO.GetAllEmployees();
        }

        // GET api/employeeapi/5
        public Employee Get(int id)
        {
            return empBO.GetDetails(id);
        }

        // POST api/employeeapi
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody]Employee emp)
        {
            //throw new ApplicationException("a");
            if (ModelState.IsValid && emp != null)
            {
                  empBO.Insert(emp);
                //After inserting we are returning all the employee records.
                return request.CreateResponse(HttpStatusCode.OK, empBO.GetAllEmployees());
            }
            else
                return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }
        
        private IEnumerable<string> GetErrorMessages()
        {
            //Returns an array of error messages.
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
        
        // PUT api/employeeapi/5
        public HttpResponseMessage Put(int id, [FromBody]Employee emp)
        {
            //throw new ApplicationException("a");
            if (ModelState.IsValid && emp != null)
            {
                empBO.Update(emp);
                //After inserting we are returning all the employee records.
                return Request.CreateResponse(HttpStatusCode.OK, empBO.GetAllEmployees());
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        // DELETE api/employeeapi/5
        public HttpResponseMessage Delete(int id)
        {
            empBO.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, empBO.GetAllEmployees());
        }
    }
}
