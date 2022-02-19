using Api2.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Abstract.Repository
{
    public interface ICommentRepo
    {
        Comment AddComment(Comment comment);
        void RemoveComment(int commentıd);
    }
}
