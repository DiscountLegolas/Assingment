using Api2.EfCore.Models;
using Api2.Models.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Abstract.Repository
{
    public interface IUserRepository
    {
        User AddUser(User addUser);
        User UpdateUser(int userıd,User updateuser);
        void DeleteUser(int userıd);
    }
}
