using Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Abstract.Repository
{
    public interface ICommentRepo
    {
        List<Comment> GetCommentsMadeByUser(int userıd);
        List<Comment> GetCommentsAtEntry(int entryıd);
    }
}
