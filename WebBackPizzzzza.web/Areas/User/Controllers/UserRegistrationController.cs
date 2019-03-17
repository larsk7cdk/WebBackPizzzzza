using Microsoft.AspNetCore.Mvc;

namespace WebBackPizzzzza.web.Areas.User.Controllers
{
    [Area("User")]
    public class UserRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}