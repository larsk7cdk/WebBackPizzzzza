using System.Collections.Generic;

namespace WebBackPizzzzza.web.ViewModels
{
    public class OrderViewModel
    {
        public double PriceTotal { get; set; }
        public IList<OrderLineViewModel> OrderLines { get; set; }
    }

    public class OrderLineViewModel
    {
        public string Name { get; set; }
        public int NoOfItems { get; set; }
        public double LinePriceTotal { get; set; }
    }
}