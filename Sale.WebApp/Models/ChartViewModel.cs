using System.Collections.Generic;

namespace CrazySale.Models
{
    public class ChartViewModel
    {
        public List<int> ProductAmountsOnCart { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}