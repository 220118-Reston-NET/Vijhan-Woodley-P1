// See https://aka.ms/new-console-template for more information
global using Serilog;
using P0Model;
using P0DL;
using P0BL;
using P0UI;
using Microsoft.Extensions.Configuration;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();

    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

    string _connectionStrings = configuration.GetConnectionString("Reference2DB");

bool repeat = true;
IMenu menu = new MainMenu();
while(repeat) 
{
Console.Clear();
menu.Display();
string ans = menu.UserChoice();

switch (ans)
{
    case "ViewSmoothies":
    Log.Information("Displaying Smoothie Information to the user");
    menu = new SmoCollection();
    break;
    
    case "SearchCustomer":
    Log.Information("Displaying SearchSmoothie Menu to the user");
    menu = new SearchCustomer(new CustomerBL(new CRepository(_connectionStrings)));
    break;

    case "AddSmoothie":
    Log.Information("Displaying AddSmoothie Menu to the user");
    menu = new AddSmoothie(new CustomerBL(new CRepository(_connectionStrings)), new SmoothieBL(new Repository(_connectionStrings)));
    break;

    case "CustomerInfo":
    Log.Information("Displaying add Customer Info Menu to the user");
    menu = new CustomerInfo(new CustomerBL(new CRepository(_connectionStrings)));
    break;

    case "ViewOrderHistory":
    Log.Information("Displaying order history menu to the user");
    menu = new ViewOrderHistory(new CustomerBL(new CRepository(_connectionStrings)));
    break;

    case "ViewStoreInventory":
    Log.Information("Displaying view store inventory to the user");
    menu = new ViewStoreInventory(new SmoothieBL(new Repository(_connectionStrings)));
    break;

    case "Exit":
    Log.Information("Exiting Application");
    Log.CloseAndFlush();
    repeat = false;
    break;

    case "MainMenu":
    Log.Information("Displaying MainMenu to user");
    menu = new MainMenu();
    break;

    case "ManagerMenu":
    Log.Information("Manager logged in, displaying ManagerMenu");
    menu = new ManagerMenu();
    break;

    case "CustomerMenu":
    Log.Information("Displaying CustomerMenu.");
    menu = new CustomerMenu();
    break;

    default:
    Console.WriteLine("Please enter valid response.");
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();
    break;
}
}
/*Console.WriteLine("cuppsize:");
string l = Console.ReadLine();
Console.WriteLine("combo num:");
int num = Convert.ToInt32(Console.ReadLine());
SmoothieModel sm = new SmoothieModel(num, l);
Console.WriteLine(sm.Name + sm.CupSize + sm.Price);*/

