using System;
using System.Collections.Generic;

namespace Sale.Data.Model
{
    public class Category:BaseEntity
    {
        public Category()
        {
        }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
