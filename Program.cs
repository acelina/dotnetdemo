using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoDotnet.Data;
var builder = WebApplication.CreateBuilder(args);

// Load the connection string from environment variables if available, otherwise from appsettings
var connectionString = Environment.GetEnvironmentVariable("DemoDotnetContext") ?? builder.Configuration.GetConnectionString("DemoDotnetContext") ?? throw new InvalidOperationException("Connection string 'DemoDotnetContext' not found.");

builder.Services.AddDbContext<DemoDotnetContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
