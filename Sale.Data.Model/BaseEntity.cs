using System;
namespace Sale.Data.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }

        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
