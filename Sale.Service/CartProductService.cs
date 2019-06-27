using Sale.Data.Infrastructure;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Service
{
    public interface ICartProductService : IServiceBase<CartProduct>
    {

    }
    public class CartProductService : ICartProductService
    {
        private readonly IRepository<CartProduct> _cartProductRepo;
        private readonly IUnitOfWork _unitOfWork;
        public CartProductService(IRepository<CartProduct> cartProductRepo, IUnitOfWork unitOfWork)
        {
            _cartProductRepo = cartProductRepo;
            _unitOfWork = unitOfWork;
        }
        public void Add(CartProduct entity)
        {
            _cartProductRepo.Add(entity);
        }

        public void Delete(CartProduct entity)
        {
            _cartProductRepo.Delete(entity);
        }

        public void Delete(long id)
        {
            _cartProductRepo.Delete(id);
        }

        public CartProduct GetById(long id)
        {
            return _cartProductRepo.GetById(id);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(CartProduct entity)
        {
            _cartProductRepo.Update(entity);
        }
    }
}
