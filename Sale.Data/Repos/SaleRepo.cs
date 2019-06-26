using System;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Data.Repos
{
    public class SaleRepo : Repository<Model.Sale>, ISaleRepo
    {
        public SaleRepo(UnitOfWork context)
            : base(context)
        { }
    }

    public interface ISaleRepo : IRepository<Model.Sale>
    {

    }
}
