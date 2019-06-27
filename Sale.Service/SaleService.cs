using System;
using System.Collections.Generic;
using System.Text;
using Sale.Data.Infrastructure;
using Sale.Data.Model;

namespace Sale.Service
{
    public interface ISaleService : IServiceBase<Sale.Data.Model.Sale>
    {

    }
    public class SaleService : ISaleService
    {
        private readonly IRepository<Data.Model.Sale> _saleRepo;
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(IRepository<Data.Model.Sale> saleRepo, IUnitOfWork unitOfWork)
        {
            _saleRepo = saleRepo;
            _unitOfWork = unitOfWork;
        }

        public void Add(Data.Model.Sale entity)
        {
            _saleRepo.Add(entity);
        }

        public void Delete(Data.Model.Sale entity)
        {
            _saleRepo.Delete(entity);
        }

        public void Delete(long id)
        {
            _saleRepo.Delete(id);
        }

        public Data.Model.Sale GetById(long id)
        {
            return _saleRepo.GetById(id);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(Data.Model.Sale entity)
        {
            _saleRepo.Update(entity);
        }
    }
}
