using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreMVC
{
  public class CityDB
  {
    private DBWebAPIContext db = new();
    public Cities GetCity(int id)
    {
      Cities City = db.Cities.Find(id);
      return City;
    }
    public IEnumerable<Cities> GetCities()
    {
      IEnumerable<Cities> Cities = db.Cities.ToList();
      return Cities;
    }
    public Cities Insert(Cities city)
    {
      db.Cities.Add(city);
      db.SaveChanges();
      return city;
    }
    public void Update(Cities city)
    {
      db.Entry(city).State = EntityState.Modified;
      db.SaveChanges();
    }
    public void Delete(int id)
    {
      Cities City = db.Cities.Find(id);
      db.Cities.Remove(City);
      db.SaveChanges();
    }
  }
}
