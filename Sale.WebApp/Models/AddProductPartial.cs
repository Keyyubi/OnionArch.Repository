using Sale.Data.Model;
using System.Collections.Generic;

namespace Sale.WebApp.Models
{
    public class AddProductPartial
    {
        public Product product { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
