using Sale.Data.Infrastructure;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Service
{
    public interface IUserService : IServiceBase<User>
    {
        bool Login(User user);
        User CurrentUser();
        long CurrentUserId();
        bool LogOut(User user);
    }
    public class UserService : IUserService
    {
        private IRepository<User> _userRepo;
        private IUnitOfWork _unitOfWork;
        private static User _currentUser { get; set; }

        public UserService(IRepository<User> userRepo, IUnitOfWork unitOfWork, ICartService cartService)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }
        public void Add(User entity)
        {
            _userRepo.Add(entity);
        }

        public User CurrentUser()
        {
            return _currentUser;
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

        public bool Login(User user)
        {
            User check = _userRepo.Get(x => x.Username == user.Username);
            if (check != null && check.Password.Equals(user.Password))
            {
                check.IsAuthenticate = true;
                _userRepo.Update(check);
                _currentUser = check;
                return true;
            }
            else
                return false;
        }

        public bool LogOut(User user)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public void Update(User entity)
        {
            _userRepo.Update(entity);
        }

        public long CurrentUserId()
        {
            return _currentUser != null ? _currentUser.Id : -1;
        }
    }
}
