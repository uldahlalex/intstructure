namespace Infa;

public class MyFakeDatabase
{
    public MyFakeDatabase()
    {
        Console.WriteLine("Database has been created");
    }
    
    public List<object> MyObjects = new List<object>();
}
