using System;
namespace Sale.Data.Model
{
    public class CartProduct
    {
        public CartProduct()
        {
        }
        public long Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int OnCartAmount { get; set; }
    }
}
