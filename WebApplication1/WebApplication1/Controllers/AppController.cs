using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
public class AppController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

}
