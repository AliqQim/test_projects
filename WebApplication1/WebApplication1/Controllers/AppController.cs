using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
public class AppController : Controller
{
    
    public IActionResult Index()
    {

        var pictureUrl = User?.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
        ViewBag.PictureUrl = pictureUrl;
        ViewBag.IsAuthenticated = User?.Identity?.IsAuthenticated == true;


        return View();
    }

}
