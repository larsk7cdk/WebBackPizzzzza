using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Models;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, IEmailService emailService)
        {
            _orderService = orderService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var order = await _orderService.GetOrder();

            return View(order);
        }

        public async Task<IActionResult> SendOrder()
        {
            var order = await _orderService.GetOrder();
            var result = await _emailService.SendEmail(new EmailModel());

            if (result)
            {
                _orderService.ClearOrder();
                return RedirectToAction("Index", "Confirmation");
            }

            return RedirectToAction("Index", order);
        }
    }
}