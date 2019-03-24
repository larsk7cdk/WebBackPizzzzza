using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebBackPizzzzza.web.Models;

namespace WebBackPizzzzza.web.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IStringLocalizer<UserRegistrationController> _localizer;

        public UserRegistrationController(IStringLocalizer<UserRegistrationController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {        // Retrieves the requested culture
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var culture = rqf.RequestCulture.Culture;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistration model)
        {

    


            if (ModelState.IsValid)
            {
                //await _userService.RegisterUser(userModel);
                //return RedirectToAction(nameof(EmailConfirmation), new { userModel.Email });

                //return Content($"User {userModel.FirstName} {userModel.LastName} has been registered sucessfully");
            }

            return View(model);
        }

        public IActionResult SetCulture(string culture)
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