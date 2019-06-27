using System.Collections.Generic;
using Sale.Data.Model;

namespace Sale.WebMVC.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
        }

        public IEnumerable<Product> Products { get; set; }
    }
}
