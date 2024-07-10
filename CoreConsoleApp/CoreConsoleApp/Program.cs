using CoreConsoleApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<ProfileService>();

var app = builder.Build();
app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<ProfileService>(
        path: "/ProfileService",
        encoder: new SoapEncoderOptions(),
        serializer: SoapSerializer.DataContractSerializer,
        caseInsensitivePath: true);
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();
