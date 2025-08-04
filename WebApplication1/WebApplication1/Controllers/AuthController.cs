using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("login-google")]
    public IActionResult LoginWithGoogle(string returnUrl = "/")
    {
        var props = new AuthenticationProperties { RedirectUri = returnUrl };
        return Challenge(props, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }
}
