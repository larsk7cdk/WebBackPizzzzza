using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackPizzzzza.web.Services
{
    public interface IBasketService
    {
        int NoOfProductsInBasket { get; }
        IDictionary<int, int> GetBasketProducts { get; }
        void ClearBasket();
        Task AddToBasket(int id);
        Task RemoveFromBasket(int id);
    }

    public class BasketService : IBasketService
    {
        private static readonly ConcurrentDictionary<int, int> BasketProducts = new ConcurrentDictionary<int, int>();

        int IBasketService.NoOfProductsInBasket => BasketProducts.Sum(x => x.Value);

        IDictionary<int, int> IBasketService.GetBasketProducts => BasketProducts;

        public void ClearBasket() => BasketProducts.Clear();

        public async Task AddToBasket(int id) =>
            await Task.FromResult(BasketProducts.AddOrUpdate(id, 1, (key, oldValue) => oldValue + 1));

        public async Task RemoveFromBasket(int id) =>
            await Task.FromResult(BasketProducts.AddOrUpdate(id, 1, (key, oldValue) =>
            {
                var newValue = oldValue - 1;
                return newValue <= 0 ? 0 : newValue;
            }));
    }
}