using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProductById(int id);
        Task UpdateBasket(int id, int items);
    }

    public class ProductService : IProductService
    {
        private readonly IList<ProductViewModel> _products = new List<ProductViewModel>
        {
            new ProductViewModel {Id = 1, Name = "Bahamas", Price = 89.00, ImageUrl = "~/", Basket = 0},
            new ProductViewModel {Id = 2, Name = "New York", Price = 79.00, ImageUrl = "~/", Basket = 0},
            new ProductViewModel {Id = 3, Name = "Manhattan", Price = 89.00, ImageUrl = "~/", Basket = 0},
            new ProductViewModel {Id = 8, Name = "Las Vegas", Price = 99.00, ImageUrl = "~/", Basket = 0},
            new ProductViewModel {Id = 9, Name = "Seattle", Price = 59.00, ImageUrl = "~/", Basket = 0}
        };

        public async Task<IEnumerable<ProductViewModel>> GetProducts() => await Task.Run(() => _products.OrderBy(x => x.Name));

        public async Task<ProductViewModel> GetProductById(int id) => await Task.Run(() => _products.FirstOrDefault(x => x.Id.Equals(id)));

        public async Task UpdateBasket(int id, int items)
        {
            var product = await GetProductById(id);
            _products.Remove(product);

            product.Basket += items;

            if (product.Basket < 0)
                product.Basket = 0;

            _products.Add(product);
        }
    }
}