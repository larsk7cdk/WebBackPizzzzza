using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebBackPizzzzza.web.Controllers;

namespace WebBackPizzzzza.web.Filters
{
    public class UserRegistrationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = $"{context.ActionDescriptor.RouteValues["controller"]}Controller";
            var user = context.HttpContext.Session.GetString("userEmail");

            if (user == null && controllerName != nameof(UserRegistrationController))
                context.Result =
                    new RedirectToActionResult("Index", "UserRegistration", null);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}