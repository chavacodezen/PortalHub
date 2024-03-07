using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using PortalHub.Models;
using PortalHub.Services.Contract;
using PortalHub.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PortalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LacroixConnection"));
});
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.LoginPath = "/Init/LogIn"; options.ExpireTimeSpan = TimeSpan.FromMinutes(30); });
// Delete User Logged Cache
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Init}/{action=LogIn}/{id?}");

app.Run();
