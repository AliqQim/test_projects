using Serilog.Formatting.Json;


using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

SetupLogging(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();


void SetupLogging(IServiceCollection services)
{
    Log.Logger = new LoggerConfiguration()  //initializing a serilog singleton
        .WriteTo.Console(new JsonFormatter())

        //will look like "log-20231012.json", customizing if the suffix
        //is currently not supported - https://stackoverflow.com/questions/60228026/serilog-how-to-customize-date-in-rolling-file-name
        //but may be will be in future - https://github.com/serilog/serilog-sinks-file/pull/84
        .WriteTo.File(new JsonFormatter(), "log-.json",     
            rollingInterval:RollingInterval.Day)

        .CreateLogger();

    services.AddLogging(options =>options.AddSerilog());
    
}
