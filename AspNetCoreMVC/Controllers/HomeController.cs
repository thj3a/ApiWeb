using AspNetCoreMVC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using AspNetCoreMVC;
using System.Net.Http;
using System.Web.Http;
using System.Net;



namespace AspNetCoreMVC
{
  [System.Web.Http.Route("api/[controller]")]
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    CityDB CityDB = new();
    
    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
      object model = JsonConvert.SerializeObject(CityDB.GetCities(), Formatting.None, settings);
      return View(model); //Model is string with collection of Data in JSON format
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