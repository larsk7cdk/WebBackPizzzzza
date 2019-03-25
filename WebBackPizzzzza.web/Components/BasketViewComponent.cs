using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web.Components
{
    public  class BasketViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public BasketViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var noOfProducts = _basketService.NoOfProductsInBasket;

            return View(noOfProducts);
        }
    }
}