using System;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class CartProductRepo : Repository<CartProduct>, ICartProductRepo
    {
        public CartProductRepo(UnitOfWork context)
            : base(context)
        { }
    }

    public interface ICartProductRepo : IRepository<CartProduct>
    {

    }
}
