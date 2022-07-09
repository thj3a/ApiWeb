namespace WebAppApi.Data
{
  public class StateDB
  {
    private DBWebAPIContext DB = new();
    public IEnumerable<States> GetAllStates()
    {
      return DB.States;
    }
  }
}
