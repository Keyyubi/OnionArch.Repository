using System;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class CartRepo : Repository<Cart>, ICartRepo
    {
        public CartRepo(UnitOfWork context)
            : base(context)
        { }
    }

    public interface ICartRepo : IRepository<Cart>
    {

    }
}
