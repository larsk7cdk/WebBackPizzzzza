using System.Collections.Generic;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }

    public class ProductService : IProductService
    {
        private readonly IList<ProductViewModel> _products = new List<ProductViewModel>
        {
            new ProductViewModel {Id = 1, Name = "Bahamas", Price = 89.00, ImageUrl = "~/"},
            new ProductViewModel {Id = 2, Name = "New York", Price = 89.00, ImageUrl = "~/"},


        };

        public IEnumerable<ProductViewModel> GetProducts() => _products;

    }
}