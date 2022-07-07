using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using WebAppApi.Models;
using WebAppApi.Data;
using System.Collections;

namespace WebAppApi.Controllers
{
  public class HomeController : Controller
  {
    CityDB _cityDB = new();
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
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
    public IActionResult Index()
    {

      //var json = System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      //json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
      //json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      var settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
      object model = JsonConvert.SerializeObject(Get(), Formatting.None, settings);
      return View(model); 
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}