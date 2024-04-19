using aliksoft.AdminWebApp;
using aliksoft.DataAccessLayer;
using aliksoft.WebCommon;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//TODO make appropriate logging
//TODO get rid of duplication of bootstrap code in the two web apps

var builder = WebApplication.CreateBuilder(args);

Bootstrap.SetupCommonServices(builder);

Bootstrap.SetupLogging(builder.Services, builder.Environment.IsDevelopment());

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(RolePolicies.SuperAdminOnly, policy => policy.RequireRole(Roles.SuperAdmin));
});


var mvcBuilder = builder.Services.AddControllersWithViews(options =>
    options.Filters.Add(new AdminAppAuthorizeFilter()));

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}


var app = builder.Build();

Bootstrap.SetupApp(app);

const string DefaultController = "MainPageText";
const string DefaultAction = "Edit";


app.MapControllerRoute(
    name: "defaultUnderArea",
    pattern: $"{{area:exists}}/{{controller={DefaultController}}}/{{action={DefaultAction}}}/{{id?}}");

app.MapControllerRoute(
    name: "default",
    pattern: $"{{controller={DefaultController}}}/{{action={DefaultAction}}}/{{id?}}");

app.MapRazorPages();    //for the Identity at least


await using (var scope = app.Services.CreateAsyncScope())
{
    await SeedRoles(scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>());
}


app.Run();

async Task SeedRoles(RoleManager<IdentityRole> roleManager)
{
    string[] roleNames = { Roles.Admin, Roles.SuperAdmin };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

