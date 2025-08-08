using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new ArgumentNullException();
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new ArgumentNullException();
    options.SaveTokens = true;
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");

    //options.Events.OnCreatingTicket = ctx =>
    //{
    //    var raw = ctx.User.ToString();  //this is how we can see raw data from provider (all claims)

    //    return Task.CompletedTask;
    //};

    options.ClaimActions.MapJsonKey("picture", "picture");
});


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
       name: "default",
       pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
