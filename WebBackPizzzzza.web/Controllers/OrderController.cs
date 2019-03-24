using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Services;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBasketService _basketService;

        public OrderController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task< IActionResult> Index()
        {
            IList<ProductViewModel> products = await _basketService.ProductsInBasket();

            return View(products);
        }
    }
}