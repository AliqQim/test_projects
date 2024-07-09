using CoreConsoleApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<ProfileService>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<ProfileService>(
        path: "/ProfileService",
        encoder: new SoapEncoderOptions(),
        serializer: SoapSerializer.DataContractSerializer,
        caseInsensitivePath: true);
});

app.Run();
