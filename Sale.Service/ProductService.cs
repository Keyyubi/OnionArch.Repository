using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Service
{
    public interface IProductService : IServiceBase<Product>
    {
        Product Get(Expression<Func<Product, bool>> where);
        IEnumerable<Product> GetOnSaleProducts();
        IEnumerable<Product> GetAll();

    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public Product GetById(long id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(long id)
        {
            _productRepository.Delete(id);
        }

        public void Delete(Product p)
        {
            _productRepository.Delete(p);
        }
        
        public IEnumerable<Product> GetOnSaleProducts()
        {
            // ?? Should this query be in Repository layer?
            return _productRepository.Find(x => x.Active == true);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public Product Get(Expression<Func<Product, bool>> where)
        {
            return _productRepository.Get(where);
        }
    }
}
