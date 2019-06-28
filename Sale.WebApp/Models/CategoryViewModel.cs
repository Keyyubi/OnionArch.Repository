using Sale.Data.Model;
using System.Collections.Generic;

namespace Sale.WebApp.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
