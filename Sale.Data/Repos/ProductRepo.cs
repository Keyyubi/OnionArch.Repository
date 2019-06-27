using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(UnitOfWork context)
            :base(context)
        { }

        public IEnumerable<Product> GetProductsOnSale(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductRepo : IRepository<Product>
    {
        IEnumerable<Product> GetProductsOnSale(Expression<Func<Product,bool>> predicate);
    }
}
