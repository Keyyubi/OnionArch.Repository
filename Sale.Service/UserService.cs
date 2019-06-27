using Sale.Data.Infrastructure;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Service
{
    public interface IUserService :  IServiceBase<User>
    {
        
    }
    public class UserService : IUserService
    {
        private IRepository<User> _userRepo;
        private IUnitOfWork _unitOfWork;

        public UserService(IRepository<User> userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }
        public void Add(User entity)
        {
            _userRepo.Add(entity);
        }

        public void Delete(User entity)
        {
            _userRepo.Delete(entity);
        }

        public void Delete(long id)
        {
            _userRepo.Delete(id);
        }

        public User GetById(long id)
        {
            return _userRepo.GetById(id);
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(User entity)
        {
            _userRepo.Update(entity);
        }
    }
}
