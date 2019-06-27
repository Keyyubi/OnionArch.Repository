using System;
namespace Sale.Data.Model
{
    public class Sale:BaseEntity
    {
        public Sale()
        {
        }
        public int UserId { get; set; }
        public string UserFullname { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentTypes PaymentType { get; set; }
    }
}
