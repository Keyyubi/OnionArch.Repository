using Sale.Data.Infrastructure;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Service
{
    public interface ICartProductService : IServiceBase<CartProduct>
    {
        IEnumerable<CartProduct> GetCartProducts(long CartId);
    }
    public class CartProductService : ICartProductService
    {
        private readonly IRepository<CartProduct> _cartProductReposiroty;
        private readonly IUnitOfWork _unitOfWork;

        public CartProductService(IRepository<CartProduct> cartProductRepository, IUnitOfWork unitOfWork)
        {
            _cartProductReposiroty = cartProductRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(CartProduct entity)
        {
            _cartProductReposiroty.Add(entity);
        }

        public void Delete(CartProduct entity)
        {
            _cartProductReposiroty.Delete(entity);
        }

        public void Delete(long id)
        {
            _cartProductReposiroty.Delete(id);
        }

        public CartProduct GetById(long id)
        {
            return _cartProductReposiroty.GetById(id);
        }

        public IEnumerable<CartProduct> GetCartProducts(long CartId)
        {
            return _cartProductReposiroty.Find(x => x.CartId == CartId);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(CartProduct entity)
        {
            _cartProductReposiroty.Update(entity);
        }
    }
}
