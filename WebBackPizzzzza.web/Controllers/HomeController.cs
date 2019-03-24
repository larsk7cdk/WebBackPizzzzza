using Microsoft.AspNetCore.Mvc;

namespace WebBackPizzzzza.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}