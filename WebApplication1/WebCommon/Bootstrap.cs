using aliksoft.DataAccessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace aliksoft.WebCommon;

public static class Bootstrap
{
    public static void SetupCommonServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<MyIdentityUser>(o => SetAuthenticationOptions(o, builder))
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            
    }


    static void SetAuthenticationOptions(IdentityOptions options, IHostApplicationBuilder builder)
    {
        options.SignIn.RequireConfirmedEmail = false;
        if (builder.Configuration["ASPNETCORE_ENVIRONMENT"] == "Development")
        {

            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredUniqueChars = 0;
        }

    }

    public static void SetupLogging(IServiceCollection services, bool isDevelopment)
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
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(options => options.AddSerilog());
        //serilog does not respect .net core's standard setup (at least for log level)

        //serilog also allows setup in the app configs

    }

    public static void SetupApp(WebApplication app)
    {

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
    }
}