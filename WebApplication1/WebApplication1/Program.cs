using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.SaveToken = true; //so we can read the token in further request handling via HttpContext.GetTokenAsync("access_token")
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,    //the sign needs to be validated (otherwise - there would be no security, soo pretty strange setting with default "false")
        IssuerSigningKey = KeysHolder.KeyForAuthentication,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


//i think it's more straight to use symmetric encryption - see previous commits
public class KeysHolder
{
    static KeysHolder()
    {
        using var rsa = new RSACryptoServiceProvider(2048);
        KeyForSignup = new RsaSecurityKey(rsa.ExportParameters(true));
        KeyForAuthentication = new RsaSecurityKey(rsa.ExportParameters(false));

    }

    public static RsaSecurityKey KeyForSignup { get; }
    public static RsaSecurityKey KeyForAuthentication { get; }
}
