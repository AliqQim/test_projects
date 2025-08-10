using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers;
public class AppController : Controller
{
    
    public IActionResult Index()
    {
        //Identity contains identity info. there can be several identities.
        //the above object contains claims (taken from all Identities I guess) (Identity + authorization info I guess)
        ViewBag.IsAuthenticated = User?.Identity?.IsAuthenticated == true;

        ViewBag.Name = User?.FindFirstValue(ClaimTypes.Name);

        var pictureUrl = User?.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
        ViewBag.PictureUrl = pictureUrl;

        return View();
    }

}
