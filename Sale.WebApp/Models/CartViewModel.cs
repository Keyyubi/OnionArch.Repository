using System.Collections.Generic;
using Sale.Data.Model;

namespace Sale.WebApp.Models
{
    public class CartViewModel
    {
        public List<int> ProductAmountsOnCart { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}