using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartBootstrap.Data;
using StartBootstrap.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>
(opt => opt.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<M001Users>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/dashboard/auth/login";//login
    options.AccessDeniedPath = "/dashboard/auth/login";
});
var app = builder.Build();

app.UseStaticFiles();
//app.UseDefaultFiles();
app.UseRouting();
app.UseAuthentication();//
app.UseAuthorization();//
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}"

 );
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
