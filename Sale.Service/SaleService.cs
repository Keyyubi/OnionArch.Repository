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
        private readonly IRepository<Data.Model.Sale> _saleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(IRepository<Data.Model.Sale> saleRepository, IUnitOfWork unitOfWork)
        {
            _saleRepository = saleRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Data.Model.Sale entity)
        {
            _saleRepository.Add(entity);
        }

        public void Delete(Data.Model.Sale entity)
        {
            _saleRepository.Delete(entity);
        }

        public void Delete(long id)
        {
            _saleRepository.Delete(id);
        }

        public Data.Model.Sale GetById(long id)
        {
            return _saleRepository.GetById(id);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(Data.Model.Sale entity)
        {
            _saleRepository.Update(entity);
        }
    }
}
