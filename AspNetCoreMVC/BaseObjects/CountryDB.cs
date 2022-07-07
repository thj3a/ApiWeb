namespace AspNetCoreMVC
{
  public class CountryDB
  {
    private DBWebAPIContext DB = new();
    public IEnumerable<Countries> GetCountries()
    {
      return DB.Countries;
    }
  }
}
