using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace Infa;

public class GroceryDatabase(DataOptions<GroceryDatabase> dataopts) : DataConnection(dataopts.Options)
{

    public ITable<GroceryItem> Groceries()
    {
        return this.GetTable<GroceryItem>();
    }
    
}

public class GroceryItem
{
    [PrimaryKey]public string Id { get; set; }
    public string GroceryName { get; set; }
    
}