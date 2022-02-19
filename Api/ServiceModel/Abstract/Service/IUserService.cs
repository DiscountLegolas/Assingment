using Api.EfCore.Models;
using Api.Models.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Abstract.Service
{
    public interface IUserService
    {
        bool ValidateUser(UserRequestDto userRequest);
        User GetUser(UserRequestDto userRequest);
        List<Entry> GetEntriesByUser(int userıd);
        List<Comment> GetCommentsMadeByUser(int userıd);
    }
}
