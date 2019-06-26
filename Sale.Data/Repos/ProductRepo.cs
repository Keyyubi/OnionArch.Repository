using System;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(UnitOfWork context)
            :base(context)
        { }
    }

    public interface IProductRepo : IRepository<Product>
    {

    }
}
