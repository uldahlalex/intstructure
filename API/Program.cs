using Infa;
using Microsoft.AspNetCore.Mvc;
using Serivce;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGroceryService, GroceryService>();
builder.Services.AddSingleton<MyFakeDatabase>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();

public class MyGroceryController : ControllerBase
{
    private readonly IGroceryService groceryService;

    public MyGroceryController(IGroceryService groceryService)
    {
        Console.WriteLine("Controller has been instantied");
        this.groceryService = groceryService;
    }
    
    [HttpGet(nameof(GetGroceries))]
    public List<object> GetGroceries()
    {
        return groceryService.GetGroceries();
    }
}