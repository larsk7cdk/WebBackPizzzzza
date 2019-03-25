using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Components
{
    public class ProductViewComponent : ViewComponent
    {
        public ProductViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel viewModel)
        {
            return View(viewModel);
        }

        public void Add(int id)
        {
            
        }
    }
}