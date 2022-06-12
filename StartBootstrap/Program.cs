using Microsoft.EntityFrameworkCore;
using StartBootstrap.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>
(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

app.UseStaticFiles();
//app.UseDefaultFiles();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}"

 );
//app.MapGet("/", () => "Hello World!");

app.Run();
