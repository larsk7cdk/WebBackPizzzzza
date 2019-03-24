using System.Collections.Generic;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IBasketService
    {
        Task AddToBasket(ProductViewModel model);
        Task<int> NoOfProductsInBasket();
        Task<IList<ProductViewModel>> ProductsInBasket();
    }

    public class BasketService : IBasketService
    {
        private static readonly IList<ProductViewModel> Products = new List<ProductViewModel>();

        public Task AddToBasket(ProductViewModel model) => Task.Run(() => { Products.Add(model); });
        public Task<int> NoOfProductsInBasket() => Task.Run(() => Products.Count);
        public Task<IList<ProductViewModel>> ProductsInBasket() => Task.Run(() => Products);
    }
}