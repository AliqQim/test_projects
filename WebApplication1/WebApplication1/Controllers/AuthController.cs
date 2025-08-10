using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers;
[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("login-google")]
    public IActionResult LoginWithGoogle(string returnUrl = "/app")
    {
        var props = new AuthenticationProperties { RedirectUri = returnUrl };
        return Challenge(props, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {

        await HttpContext.SignOutAsync();
        return Redirect("/app");
    }


    [HttpPost("login-custom")]
    public async Task<IActionResult> LoginCustom([FromForm] string username, [FromForm] string password)
    {
        if (username == "admin" && password == "password")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            //the one who created a ClaimsIdentity - sets it's scheme of creation, which then is a part of the principal
            //object which would be serialized in cookie (due to the default scheme settings)
            var claimsIdentity = new ClaimsIdentity(claims, "AlikFormAuthenticated");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            //saving the auth data (to cookies)
            await HttpContext.SignInAsync(
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Redirect("/app");
        }

        return Unauthorized("Wrong login or password");
    }


}
