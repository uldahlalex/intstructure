using Infa;
using LinqToDB;
using LinqToDB.Internal.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serivce;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGroceryService, GroceryService>();

var connectionstring = "Data Source=dev.db";
var options = new DataOptions().UseSQLite(connectionstring);
var dataopts = new DataOptions<GroceryDatabase>(options);

builder.Services.AddScoped<GroceryDatabase>(_ => new GroceryDatabase(dataopts));

builder.Services.AddControllers();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider
        .GetRequiredService<GroceryDatabase>()
        .CreateTable<GroceryItem>(tableOptions:TableOptions.CreateIfNotExists);
}

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
    public List<GroceryItem> GetGroceries()
    {
        return groceryService.GetGroceries();
    }
    
    [HttpGet(nameof(InsertGroceryItem))]
    public void InsertGroceryItem()
    {
         groceryService.InsertGroceryItem();
    }
}