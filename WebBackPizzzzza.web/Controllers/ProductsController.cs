using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index([FromServices] IProductService productService)
        {
            var products = productService.GetProducts();

            return View(products);
        }
    }
}