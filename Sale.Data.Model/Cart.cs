using System;
namespace Sale.Data.Model
{
    public class Cart:BaseEntity
    {
        public Cart()
        {
        }
        public long UserId { get; set; }
        public long? SaleId { get; set; }
    }
}
