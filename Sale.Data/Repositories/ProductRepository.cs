using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Product> GetOnSaleProducts()
        {
            return Find(x => x.Active == true);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetOnSaleProducts();
    }
}
