using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();

            return View(products);
        }

        public async Task<IActionResult> AddToBasket([FromRoute] int id, [FromServices] IBasketService basketService)
        {
            var product = await _productService.GetProductById(id);
            await basketService.AddToBasket(product);

            return RedirectToAction("Index");
        }
    }
}