using Microsoft.AspNetCore.Mvc;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Components
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ProductViewModel viewModel) => View(viewModel);
    }
}