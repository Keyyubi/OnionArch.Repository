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
        Cart GetUserCart();
    }

    public class CartService : ICartService
    {
        private IRepository<Cart> _cartReposiroty;
        private IUnitOfWork _unitOfWork;

        public CartService(IRepository<Cart> cartRepository, IUnitOfWork unitOfWork)
        {
            _cartReposiroty = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Cart cart)
        {
            _cartReposiroty.Add(cart);
        }

        public Cart GetById(long id)
        {
            return _cartReposiroty.GetById(id);
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartReposiroty.GetAll();
        }

        public void Update(Cart cart)
        {
            _cartReposiroty.Update(cart);
        }

        public void Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            _cartReposiroty.Delete(id);
        }


        public Cart GetUserCart()
        {
            long UserId = UserService.CurrentUser.Id;
            var obj = _cartReposiroty.Get(x => x.UserId == UserId);

            if (obj == null)
            {
                _cartReposiroty.Add(new Cart { UserId = UserId });
                _unitOfWork.Commit();
                obj = _cartReposiroty.Get(x => x.UserId == UserId);
            }

            return obj;
        }


        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }
    }
}
