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
    public string? GetCities()
    {
      //var json = System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      //json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
      //json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      var settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
      var result = _cityDB.GetCities();
      var model = JsonConvert.SerializeObject(result, Formatting.None, settings);
      return model;
    }

    public Cities GetCity(int id)
    {
      return _cityDB.GetCity(id);
    }
    public IEnumerable Get()
    {
      return _cityDB.GetCities();
    }
    public IActionResult Index()
    {

      ////var json = System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      ////json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
      ////json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      //var settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
      //object model = JsonConvert.SerializeObject(Get(), Formatting.None, settings);
      //return View(model);
      return View();
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