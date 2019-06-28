using System.Collections.Generic;
using Sale.Data.Model;

namespace Sale.WebApp.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}