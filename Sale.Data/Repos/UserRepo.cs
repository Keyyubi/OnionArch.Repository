using System;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public UserRepo(UnitOfWork context)
            : base(context)
        { }
    }

    public interface IUserRepo : IRepository<User>
    {

    }
}
