﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Service
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> GetOnSaleProducts();
    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> productRepo, IUnitOfWork unitOfWork)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            _productRepo.Add(product);
        }

        public Product GetById(long id)
        {
            return _productRepo.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public void Update(Product product)
        {
            _productRepo.Update(product);
        }

        public void Delete(long id)
        {
            _productRepo.Delete(id);
        }

        public void Delete(Product p)
        {
            _productRepo.Delete(p);
        }
        
        public IEnumerable<Product> GetOnSaleProducts()
        {
            // ?? Should this query be in Repository layer?
            return _productRepo.GetMany(x => x.Active == true);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }
    }
}