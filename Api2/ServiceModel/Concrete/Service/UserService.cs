using Api2.EfCore.Models;
using Api2.ServiceModel.Abstract.Repository;
using Api2.ServiceModel.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Concrete.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public User AddUser(User addUser)
        {
            return _repo.AddUser(addUser);
        }

        public void DeleteUser(int userıd)
        {
            _repo.DeleteUser(userıd);
        }

        public User UpdateUser(int userıd,User updateuser)
        {
            return _repo.UpdateUser(userıd, updateuser);
        }
    }
}
