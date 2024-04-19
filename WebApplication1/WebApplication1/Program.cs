using Serilog.Formatting.Json;


using Serilog;
using Serilog.Events;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using aliksoft.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using aliksoft.WebCommon;




var builder = WebApplication.CreateBuilder(args);

Bootstrap.SetupCommonServices(builder);

Bootstrap.SetupLogging(builder.Services, builder.Environment.IsDevelopment());


var mvcBuilder = builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();    //for the Identity at least

app.Run();




