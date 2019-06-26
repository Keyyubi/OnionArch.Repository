using System;
namespace Sale.Data.Model
{
    public class Product:BaseEntity
    {
        public Product()
        {
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
