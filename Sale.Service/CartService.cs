using Sale.Data.Infrastructure;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sale.Service
{
    public interface ICartService : IServiceBase<Cart>
    {
        Cart GetUserCart(long UserId);
    }

    public class CartService : ICartService
    {
        private IRepository<Cart> _cartRepo;
        private IUnitOfWork _unitOfWork;

        public CartService(IRepository<Cart> cartRepo, IUnitOfWork unitOfWork)
        {
            _cartRepo = cartRepo;
            _unitOfWork = unitOfWork;
        }

        public void Add(Cart cart)
        {
            _cartRepo.Add(cart);
        }

        public Cart GetById(long id)
        {
            return _cartRepo.GetById(id);
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartRepo.GetAll();
        }

        public void Update(Cart cart)
        {
            _cartRepo.Update(cart);
        }

        public void Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            _cartRepo.Delete(id);
        }


        public Cart GetUserCart(long UserId)
        {
            var obj = _cartRepo.Get(x => x.UserId == UserId);

            if (obj == null)
            {
                _cartRepo.Add(new Cart { UserId = UserId });
                obj = _cartRepo.Get(x => x.UserId == UserId);
            }

            return obj;
        }


        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }
    }
}
