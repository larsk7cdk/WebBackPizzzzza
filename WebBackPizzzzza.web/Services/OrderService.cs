using System.Collections.Generic;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetOrderProducts();
    }

    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public OrderService(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrderProducts()
        {
            IList<OrderViewModel> basketProducts = new List<OrderViewModel>();

            foreach (var (id, no) in _basketService.GetBasketProducts)
            {
                var product = await _productService.GetProductById(id);
                basketProducts.Add(new OrderViewModel { Name = product.Name, NoOfItems = no });
            }

            return basketProducts;
        }
    }
}