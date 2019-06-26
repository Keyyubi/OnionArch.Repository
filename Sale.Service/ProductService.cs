using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sale.Data.Infrastructure;
using Sale.Data.Model;
using Sale.Data.Repos;

namespace Sale.Service
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product GetProduct(long id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetOnSaleProducts();
        void UpdateProduct(Product p);
        void DeleteProduct(long ID);
        int SaveProduct();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepo productRepo, IUnitOfWork unitOfWork)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(Product product)
        {
            _productRepo.Add(product);
        }

        public void DeleteProduct(long id)
        {
            var product = _productRepo.GetById(id);
            _productRepo.Delete(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public IEnumerable<Product> GetOnSaleProducts()
        {
            return _productRepo.GetMany(x => x.Active == true);
        }

        public Product GetProduct(long id)
        {
            return _productRepo.GetById(id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepo.Update(product);
        }

        public int SaveProduct()
        {
            return _unitOfWork.Commit();
        }
    }
}
