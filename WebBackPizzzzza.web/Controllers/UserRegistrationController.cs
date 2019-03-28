using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Controllers
{
    public class UserRegistrationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>()
                .RequestCulture.Culture.ToString();

            return View();
        }

        [HttpPost]
        public IActionResult Index(UserRegistrationViewModel model)
        {
            ViewBag.CurrentCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>()
                .RequestCulture.Culture.ToString();

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("userEmail", model.Email);
                return RedirectToAction("Index", "Products");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SetCulture([FromQuery]string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions {Expires = DateTimeOffset.UtcNow.AddYears(1)}
            );

            ViewBag.CurrentCulture = culture;

            return View("Index");
        }
    }
}