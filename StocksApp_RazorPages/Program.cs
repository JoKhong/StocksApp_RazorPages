using FinnhubServices;
using FinnhubContracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddTransient<IFinnhubService, FinnhubService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
