using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task< IActionResult> Index()
        {
           // IList<ProductViewModel> products = await _basketService.ProductsInBasket();

           var orderViewModels = await _orderService.GetOrderProducts();

           return View();
        }
    }
}