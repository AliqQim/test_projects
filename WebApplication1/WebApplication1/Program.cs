using Serilog.Formatting.Json;


using Serilog;
using Serilog.Events;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using aliksoft.DataAccessLayer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MyIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

SetupLogging(builder.Services, builder.Environment.IsDevelopment());


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


void SetupLogging(IServiceCollection services, bool isDevelopment)
{
    //initializing a serilog singleton
    var loggingSetup = new LoggerConfiguration();  
        
    if (isDevelopment)
    {
        loggingSetup = loggingSetup.MinimumLevel.Warning()
            .MinimumLevel.Override("Aliksoft", LogEventLevel.Information);
    }
    else
    {
        loggingSetup = loggingSetup.MinimumLevel.Error()
            .MinimumLevel.Override("Aliksoft", LogEventLevel.Warning);
    }

    //will look like "log-20231012.json", customizing if the suffix
    //is currently not supported - https://stackoverflow.com/questions/60228026/serilog-how-to-customize-date-in-rolling-file-name
    //but may be will be in future - https://github.com/serilog/serilog-sinks-file/pull/84
    Log.Logger = loggingSetup.WriteTo.Console(new JsonFormatter())
        .WriteTo.File(new JsonFormatter(), "log-.json",     
            rollingInterval:RollingInterval.Day)
        .CreateLogger();

    services.AddLogging(options => options.AddSerilog());
    //serilog does not respect .net core's standard setup ()(at least for log level)

    //serilog also allows setup in the app configs

}
