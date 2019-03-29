using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IOrderService
    {
        Task<OrderViewModel> GetOrder();
        void ClearOrder();
    }

    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public OrderService(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<OrderViewModel> GetOrder()
        {
            var order = new OrderViewModel
            {
                OrderLines = new List<OrderLineViewModel>()
            };

            foreach (var (id, noOfItems) in _basketService.GetBasketProducts)
            {
                var product = await _productService.GetProductById(id);
                var priceTotel = product.Price * noOfItems;
                order.OrderLines.Add(new OrderLineViewModel
                { Name = product.Name, NoOfItems = noOfItems, LinePriceTotal = priceTotel });
            }

            order.PriceTotal = order.OrderLines.Sum(x => x.LinePriceTotal);

            return order;
        }

        public void ClearOrder()
        {
            _productService.ResetProducts();
            _basketService.ClearBasket();
        }
    }
}