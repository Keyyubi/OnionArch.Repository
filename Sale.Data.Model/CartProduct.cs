using System;
namespace Sale.Data.Model
{
    public class CartProduct
    {
        public CartProduct()
        {
        }
        public int ID { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int OnCartAmount { get; set; }
    }
}
