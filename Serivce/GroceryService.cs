using Infa;

namespace Serivce;

public interface IGroceryService
{
    public List<object> GetGroceries();
}

public class GroceryService : IGroceryService
{
    private readonly MyFakeDatabase _db;

    public GroceryService(MyFakeDatabase db)
    {
        _db = db;
        Console.WriteLine("Service has been instantied");
    }
    
    public List<object> GetGroceries()
    {
        return _db.MyObjects;
    }
}
