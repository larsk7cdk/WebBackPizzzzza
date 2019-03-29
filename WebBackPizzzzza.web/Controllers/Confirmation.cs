using Microsoft.AspNetCore.Mvc;

namespace WebBackPizzzzza.web.Controllers
{
    public class Confirmation : Controller
    {
        // GET
        public IActionResult Index()
        {
            return             View();
        }
    }
}