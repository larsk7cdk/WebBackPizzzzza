using System.Collections.Generic;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IBasketService
    {
        Task AddToBasket(ProductViewModel model);
    }

    public class BasketService : IBasketService
    {
        private static readonly IList<ProductViewModel> Products = new List<ProductViewModel>();

        public Task AddToBasket(ProductViewModel model)
        {
            return Task.Run(() => { Products.Add(model); });
        }
    }
}