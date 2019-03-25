using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackPizzzzza.web.Services
{
    public interface IBasketService
    {
        int NoOfProductsInBasket { get; }
        void ClearBasket();
        Task AddToBasket(int id);
        Task RemoveFromBasket(int id);
        Task<ConcurrentDictionary<int, int>> ProductsInBasket();
    }

    public class BasketService : IBasketService
    {
        private static ConcurrentDictionary<int, int> ProductsID = new ConcurrentDictionary<int, int>();

        int IBasketService.NoOfProductsInBasket => ProductsID.Sum(x => x.Value);

        public void ClearBasket() => ProductsID.Clear();
        
        public async Task AddToBasket(int id) =>
            await Task.FromResult(ProductsID.AddOrUpdate(id, 1, (key, oldValue) => oldValue + 1));

        public async Task RemoveFromBasket(int id) =>
            await Task.FromResult(ProductsID.AddOrUpdate(id, 1, (key, oldValue) =>
            {
                var newValue = oldValue - 1;
                return newValue <= 0 ? 0 : newValue;
            }));

        public Task<ConcurrentDictionary<int, int>> ProductsInBasket() => Task.FromResult(ProductsID);
    }
}