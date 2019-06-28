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
        private IRepository<User> _userRepository;
        private IUnitOfWork _unitOfWork;
        private static User _currentUser { get; set; }

        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(User entity)
        {
            _userRepository.Add(entity);
        }

        public User CurrentUser()
        {
            return _currentUser;
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }

        public void Delete(long id)
        {
            _userRepository.Delete(id);
        }

        public User GetById(long id)
        {
            return _userRepository.GetById(id);
        }

        public bool Login(User user)
        {
            User check = _userRepository.Get(x => x.Username == user.Username);
            if (check != null && check.Password.Equals(user.Password))
            {
                check.IsAuthenticate = true;
                _userRepository.Update(check);
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
            _userRepository.Update(entity);
        }

        public long CurrentUserId()
        {
            return _currentUser != null ? _currentUser.Id : -1;
        }
    }
}
