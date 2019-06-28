using Sale.Data.Infrastructure;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Service
{
    public interface ICategoryService : IServiceBase<Category>
    {
        void AddRange(IEnumerable<Category> ctg);
        IEnumerable<Category> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void AddRange(IEnumerable<Category> categories)
        {
            _categoryRepository.AddRange(categories);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void Delete(long id)
        {
            _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(long id)
        {
            return _categoryRepository.GetById(id);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
