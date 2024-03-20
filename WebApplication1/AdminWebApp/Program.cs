using aliksoft.AdminWebApp;
using aliksoft.DataAccessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//TODO make appropriate logging
//TODO get rid of duplication of bootstrap code in the two web apps

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MyIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddControllersWithViews(options =>
    options.Filters.Add(new AdminAppAuthorizeFilter()))
    .AddRazorRuntimeCompilation();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    //app.UseExceptionHandler("/Home/Error");   //TODO make prod error handler
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPageText}/{action=Edit}/{id?}");

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


public class AdminAppAuthorizeFilter : AuthorizeFilter
{
    public AdminAppAuthorizeFilter() : base(
        new AuthorizationPolicyBuilder()
         .RequireAuthenticatedUser()
         .RequireRole("Admin")
         .Build())
    {
    }

    public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var path = context.HttpContext.Request.Path;
        if (path.StartsWithSegments(new PathString("/Identity"), StringComparison.OrdinalIgnoreCase))
        {
            return;
        }


        await base.OnAuthorizationAsync(context);
    }
}