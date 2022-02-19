using Api.EfCore.Models;
using Api.Models.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Abstract.Repository
{
    public interface IUserRepository
    {
        User GetUser(UserRequestDto userRequest);
        bool ValidateUser(UserRequestDto userRequest);
    }
}
