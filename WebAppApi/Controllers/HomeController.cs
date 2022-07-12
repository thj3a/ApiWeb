using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using WebAppApi.Models;
using WebAppApi.Data;
using System.Collections;
using System.Net;

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

    
    public IActionResult Index()
    {
      return View();
    }
    public string? GetCities()
    {
      var settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
      var result = _cityDB.GetCities();
      var model = JsonConvert.SerializeObject(result, Formatting.None, settings);
      return model;
    }

    public Cities GetCity(int id)
    {
      return _cityDB.GetCity(id);
    }
    
    public HttpResponseMessage Post(HttpRequestMessage request, [FromBody] Cities city)
    {
      //throw new ApplicationException("a");
      if (ModelState.IsValid && city != null)
      {
        _cityDB.Insert(city);
        //After inserting we are returning all the employee records.
        return request.CreateResponse(HttpStatusCode.OK, _cityDB.GetCities());
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
    public HttpResponseMessage Put(HttpRequestMessage request, int id, [FromBody] Cities city)
    {
      //throw new ApplicationException("a");
      if (ModelState.IsValid && city != null)
      {
        _cityDB.Update(city);
        //After inserting we are returning all the employee records.
        return request.CreateResponse(HttpStatusCode.OK, _cityDB.GetCities());
      }
      else
        return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
    }

    // DELETE api/employeeapi/5
    public HttpResponseMessage Delete(HttpRequestMessage request, int id)
    {
      _cityDB.Delete(id);
      return request.CreateResponse(HttpStatusCode.OK, _cityDB.GetCities());
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