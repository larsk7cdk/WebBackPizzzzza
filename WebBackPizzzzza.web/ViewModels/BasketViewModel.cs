using System.Collections.Generic;

namespace WebBackPizzzzza.web.ViewModels
{
    public class BasketViewModel
    {
        public int Id { get; set; }

        public IList<ProductViewModel> Products { get; set; }
    }
}