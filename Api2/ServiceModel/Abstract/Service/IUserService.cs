using Api2.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Abstract.Service
{
    public interface IUserService
    {
        User AddUser(User addUser);
        User UpdateUser(int userıd,User updateuser);
        void DeleteUser(int userıd);
    }
}
