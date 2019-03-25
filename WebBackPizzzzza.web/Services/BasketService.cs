using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IBasketService
    {
        int NoOfProductsInBasket { get; }
        Task AddToBasket(int id);
        Task RemoveFromBasket(int id);
        Task<IDictionary<int, int>> ProductsInBasket();
    }

    public class BasketService : IBasketService
    {
        private static readonly IDictionary<int, int> ProductsID = new Dictionary<int, int>();

        int IBasketService.NoOfProductsInBasket => ProductsID.Count;

        public async Task AddToBasket(int id) =>
            await Task.Run(() =>
            {
                if (ProductsID.TryGetValue(id, out var count)) ProductsID.Remove(id);
                ProductsID.Add(id, count + 1);
            });

        public async Task RemoveFromBasket(int id) =>
            await Task.Run(() =>
            {
                if (ProductsID.TryGetValue(id, out var count)) ProductsID.Remove(id);
                ProductsID.Add(id, count - 1);
            });


        public Task<IDictionary<int, int>> ProductsInBasket() => Task.FromResult(ProductsID);
    }
}