using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Components
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult InvokeAsync(ProductViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}