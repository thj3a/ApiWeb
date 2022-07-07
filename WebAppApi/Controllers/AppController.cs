using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppApi.Data;
using System.Collections;

namespace WebAppApi.Controllers
{
  public class AppController : System.Web.Http.ApiController
  {
    CityDB _cityDB = new();
    public AppController()
    {
      var json = System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
      json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }
    public IEnumerable Get()
    {
      return _cityDB.GetCities();
    }

    // GET api/employeeapi/5
    public Cities Get(int id)
    {
      return _cityDB.GetCity(id);
    }
    // GET: AppController
    
  }
}
