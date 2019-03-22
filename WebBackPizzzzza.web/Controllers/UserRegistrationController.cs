using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Areas.User.Models;

namespace WebBackPizzzzza.web.Controllers
{
    public class UserRegistrationController : Controller
    {
        public IActionResult Index()
        {
            var culture = Request.HttpContext.Session.GetString("culture");
            if (string.IsNullOrEmpty(culture))
            {
                HttpContext.Session.SetString("culture", "da");
            }

            ViewBag.Culture = Request.HttpContext.Session.GetString("culture");
            ViewBag.Language = ViewBag.Culture;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistration model)
        {
            ViewBag.Culture = Request.HttpContext.Session.GetString("culture");
            if (ModelState.IsValid)
            {
                //await _userService.RegisterUser(userModel);
                //return RedirectToAction(nameof(EmailConfirmation), new { userModel.Email });

                //return Content($"User {userModel.FirstName} {userModel.LastName} has been registered sucessfully");
            }

            return View(model);
        }

        public IActionResult SetCulture(string id)
        {
            var culture = id;
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            ViewData["Message"] = "Culture set to " + culture;

            return View("Index");


            //HttpContext.Session.SetString("culture", culture);
            //return RedirectToAction("Index");
        }
    }
}