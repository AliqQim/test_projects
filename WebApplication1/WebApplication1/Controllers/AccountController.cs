using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Google");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
