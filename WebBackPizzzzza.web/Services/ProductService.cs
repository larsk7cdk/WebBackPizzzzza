using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
        Task<ProductViewModel> GetProductById(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IList<ProductViewModel> _products = new List<ProductViewModel>
        {
            new ProductViewModel {Id = 1, Name = "Bahamas", Price = 89.00, ImageUrl = "~/"},
            new ProductViewModel {Id = 2, Name = "New York", Price = 89.00, ImageUrl = "~/"},


        };

        public IEnumerable<ProductViewModel> GetProducts() => _products;

        public async Task<ProductViewModel> GetProductById(int id) => await Task.Run(() => _products.FirstOrDefault(x=> x.Id.Equals(id)));
    }
}